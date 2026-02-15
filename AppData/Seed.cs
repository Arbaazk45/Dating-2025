using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using API.DTOs;
using API.Intities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.AppData
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager)
        {
            // 1️⃣ Exit if users already exist
            if (await userManager.Users.AnyAsync()) return;

            // 2️⃣ Seed members from JSON
            var memberData = await File.ReadAllTextAsync("AppData/UserSeedData.json");
            var members = System.Text.Json.JsonSerializer.Deserialize<List<MembersDto>>(memberData);

            if (members != null)
            {
                foreach (var member in members)
                {
                    // 2a️⃣ Create AppUser
                    var user = new AppUser
                    {
                        Id = member.Id,                 // static ID from JSON
                        DisplayName = member.DisplayName,
                        Email = member.Email,
                        ImageUrl = member.ImageUrl,
                        UserName = member.Email,        // must be unique
                        Members = new Members
                        {
                            Id = member.Id,
                            DisplayName = member.DisplayName,
                            DateOfBirth = member.DateOfBirth,
                            ImageUrl = member.ImageUrl,
                            Gender = member.Gender,
                            Description = member.Description,
                            City = member.City,
                            Country = member.Country,
                            Created = DateTime.UtcNow,     // set manually
                            LastActive = DateTime.UtcNow
                        }
                    };

                    // 2b️⃣ Add photo if exists
                    if (!string.IsNullOrEmpty(member.ImageUrl))
                    {
                        user.Members.Photo.Add(new Photo
                        {
                            Url = member.ImageUrl,
                            MembersId = member.Id
                        });
                    }

                    // 2c️⃣ Create user and assign role by NAME
                    var result = await userManager.CreateAsync(user, "Pa$$w0rd123"); // strong default password
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, "Member"); // role name, not ID
                }
            }

            // 3️⃣ Seed admin user
            var admin = new AppUser
            {
                Id = "Admin-id",             // static
                DisplayName = "Admin",
                Email = "admin@admin.com",
                UserName = "admin@admin.com"
            };

            var adminResult = await userManager.CreateAsync(admin, "Admin@123"); // strong password
            if (adminResult.Succeeded)
            {
                // Assign multiple roles by NAME
                await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
            }
        }
    }
}
