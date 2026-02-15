using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Newtonsoft.Json;

namespace API.Intities;

public class Members
{
  public string Id { get; set; } = null!;
  public DateOnly DateOfBirth { get; set; }

  public string? ImageUrl { get; set; }
  public required string DisplayName { get; set; }

  public DateTime Created { get; set; } 


  public DateTime LastActive { get; set; }

  public required string Gender { get; set; }

  public string? Description { get; set; }

  public required string City { get; set; }

  public required string Country { get; set; }


  // navigation property

  [JsonIgnore]
  public List<MemberLiked> LikedByMember { get; set; } = [];
  [JsonIgnore]
  public List<MemberLiked> LikedMember { get; set; } = [];

  [JsonIgnore]
  public List<Message> MessageSent { get; set; } = [];
  [JsonIgnore]
  public List<Message> MessageRecieved { get; set; } = [];
  public List<Photo> Photo { get; set; } = [];
  [ForeignKey("Id")]

  public AppUser User { get; set; } = null!;

}
