using System;

namespace API.DTOs;

public class UserDto
{
    public required string id { get; set; }
    public required string displayName { get; set; }
    public required string email { get; set; }
    public string? imgUrl { get; set; }
    public required string token { get; set; }
}
