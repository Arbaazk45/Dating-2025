using System;

namespace API.Intities;

public class MemberLiked
{
 public required String SourceMemberId { get; set; }

 public Members sourceMember { get; set; }=null!;
 public required String TargetMemberId { get; set; }

 public Members targetMember { get; set; }=null!;

}
