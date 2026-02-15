using System;
using API.Extensions;
using API.Interfaces;
using API.Intities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LikeController(IUnitofWork uow) : BaseController
{
    [HttpPost("{targetMemberId}")]

    public async Task<ActionResult> ToggleLike(string targetMemberId)
    {
        var sourceMemberId = User.GetMemberId();
        if (sourceMemberId == targetMemberId) return BadRequest("You cannot like yourself");
        var existingLike = await uow.likedMemberRepository.GetAllMemberLikes(sourceMemberId, targetMemberId);
        if (existingLike == null)
        {
            var like = new MemberLiked
            {
                SourceMemberId = sourceMemberId,
                TargetMemberId = targetMemberId
            };
            uow.likedMemberRepository.AddMemberLike(like);
          
        }
        else
        {
            uow.likedMemberRepository.DeleteMemberLike(existingLike);

        }

        if( await uow.Complete()) return Ok();

        return BadRequest("Problem toggling like");
    }

    [HttpGet("List")]

    public async Task<ActionResult<IReadOnlyList<String>>>GetMemberLikes()
    {
        return Ok(await uow.likedMemberRepository.getMemeberWhichiIliked(User.GetMemberId()));
    }


    [HttpGet]

    public async Task <ActionResult<IReadOnlyList<Members>>> GetLikedByMembers(string predicate)
    {
        var memberId = User.GetMemberId();
        var members = await uow.likedMemberRepository.GetLikedByMembers(memberId, predicate);
        return Ok(members);
    }


}



