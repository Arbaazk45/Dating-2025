using System;
using API.Interfaces;
using API.Intities;
using Microsoft.EntityFrameworkCore;

namespace API.AppData;

public class LikedMemberRepository(AppDbContext context) : ILikeMemberRepository
{
    public void AddMemberLike(MemberLiked memberLike)
    {
        context.memberLikes.Add(memberLike);
    }

    public void DeleteMemberLike(MemberLiked memberLike)
    {
        context.memberLikes.Remove(memberLike);
    }

    public async Task<IReadOnlyList<Members>> GetLikedByMembers(string memberId, string predicate)
    {
        var query = context.memberLikes.AsQueryable();

        switch (predicate)
        {
            case "liked":
                return await query.Where(x => x.SourceMemberId == memberId).Select(x => x.targetMember).ToListAsync();

            case "likedBy":
                return await query.Where(x => x.TargetMemberId == memberId).Select(x => x.sourceMember).ToListAsync();

            default:
                var likedMember = await getMemeberWhichiIliked(memberId);
                return await context.memberLikes.Where(x => x.TargetMemberId == memberId && likedMember.Contains(x.SourceMemberId))
                .Select(x => x.sourceMember).ToListAsync();

        }
    }






    public async Task<IReadOnlyList<string>> getMemeberWhichiIliked(string memberId)
    {
        return await context.memberLikes
        .Where(x => x.SourceMemberId == memberId)
        .Select(x => x.TargetMemberId).ToListAsync();

    }

    public async Task<MemberLiked?> GetAllMemberLikes(string sourceMemberId, string targetMemberId)
    {
        return await context.memberLikes.FindAsync(sourceMemberId, targetMemberId);
    }

}
