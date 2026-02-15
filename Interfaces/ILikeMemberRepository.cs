using System;
using API.Intities;

namespace API.Interfaces;

public interface ILikeMemberRepository
{
    Task<MemberLiked?> GetAllMemberLikes(string sourceMemberId, string targetMemberId);

    Task<IReadOnlyList<string>> getMemeberWhichiIliked(string memberId);

    Task<IReadOnlyList<Members>> GetLikedByMembers(string memberId, string predicate);

    void DeleteMemberLike(MemberLiked memberLike);
    void AddMemberLike(MemberLiked memberLike);


}
