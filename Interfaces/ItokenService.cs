using System;
using API.Intities;

namespace API.Interfaces;

public interface ItokenService
{
 string createToken(AppUser user);
}
