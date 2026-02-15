using System;
using System.Security.Claims;

namespace API.Extensions;

public static class ClaimPrincipleExtension
{
  public static string GetMemberId(this ClaimsPrincipal User)
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new Exception("Member Id not found in claims");
    }

}
