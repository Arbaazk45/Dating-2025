using Microsoft.AspNetCore.Identity;

namespace API.Intities;

public class AppUser : IdentityUser
{

public required string DisplayName  { get; set; }

public string? ImageUrl { get; set; }

public  string? RefreshToken { get; set; }

public DateTime? refreshTokenExpiry { get; set; }

// navigation property
public Members Members { get; set; } =null!;
}
