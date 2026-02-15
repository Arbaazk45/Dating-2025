using System;

namespace API.Intities;

public class Photo
{
 public int Id { get; set; }

 public string ? Url { get; set;  }

 public string ? PublicId { get; set; }

 public string MembersId { get; set; }=null!;

 public Members Members { get; set; } = null!;
}
