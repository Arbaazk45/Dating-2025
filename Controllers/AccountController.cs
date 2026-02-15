using System;
using System.Security.Cryptography;
using System.Text;
using API.AppData;
using API.DTOs;
using API.Interfaces;
using API.Intities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers;

public class AccountController(UserManager<AppUser> userManager, ItokenService tokenService) : BaseController
{
    [HttpPost("register")]

    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
    {

        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Email,

            Members = new Members
            {
                DisplayName = registerDto.DisplayName,
                Gender = registerDto.Gender,
                City = registerDto.City,
                Country = registerDto.Country,
                DateOfBirth = (DateOnly)registerDto.DateOfBirth
            }

        };
        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
            return BadRequest("Username or password is incorrect"); 
        
        return new UserDto
        {
            id = user.Id,
            displayName = user.DisplayName,
            email = user.Email,
            token = tokenService.createToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return BadRequest("Username or password is incorrect");
        return new UserDto
        {
            id = user.Id,
            displayName = user.DisplayName,
            email = user.Email!,
            token = tokenService.createToken(user)
        };
    }




}

