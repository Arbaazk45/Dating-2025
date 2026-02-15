using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.AppData;
using API.Intities;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.Extensions;
using API.DTOs;
using API.AppData.Migrations;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Helpers;

namespace API.Controllers
{
    public class MembersController(IUnitofWork uow, IPhotoService photoService) : BaseController

    {
        [HttpGet]
        public async Task<ActionResult<PaginatedHelpers<Members>>> GetMembers([FromQuery] MemberParams memberParams)
        {
            memberParams.CurrentMemberId = User.GetMemberId();
            return Ok(await uow.memberRepositry.GetAllAsync(memberParams));

        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Members>> Get(string id)
        {
            var user = await uow.memberRepositry.GetMemberByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Authorize]

        public async Task<ActionResult> Update(UpdateMemberDto memberDto)
        {
            var MemberId = User.GetMemberId();

            var Member = await uow.memberRepositry.GetUpdateMemberById(MemberId);

            if (Member == null) return NotFound();

            Member.DisplayName = memberDto.DisplayName ?? Member.DisplayName;
            Member.Description = memberDto.Description ?? Member.Description;
            Member.City = memberDto.City ?? Member.City;
            Member.Country = memberDto.Country ?? Member.Country;
            Member.User.DisplayName = memberDto.DisplayName ?? Member.User.DisplayName;

            await uow.Complete();

            return NoContent();


        }

        [HttpGet("{id}/photos")]
        public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
        {
            var isCurrentUser = User.GetMemberId() == id;
            return Ok(await uow.memberRepositry.GetPhotosForMemberAsync(id, isCurrentUser));
        }


        [HttpPost("add-photo")]

        public async Task<ActionResult<Photo>> AddPhoto([FromForm] IFormFile file)
        {
            var member = await uow.memberRepositry.GetUpdateMemberById(User.GetMemberId());

            if (member == null) return BadRequest("Cannot update member");

            var result = await photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,

            };

            if (member.ImageUrl == null)
            {
                member.ImageUrl = photo.Url;
                member.User.ImageUrl = photo.Url;
            }
            member.Photo.Add(photo);
            if (await  uow.Complete()) return photo;

            return BadRequest("Problem adding photo");
        }


        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var member = await uow.memberRepositry.GetUpdateMemberById(User.GetMemberId());

            if (member == null) return BadRequest("Cannot update member");

            var photo = member.Photo.FirstOrDefault(x => x.Id == photoId);

            if (photo == null) return NotFound();

            member.ImageUrl = photo.Url;
            member.User.ImageUrl = photo.Url;

            if (await  uow.Complete()) return NoContent();

            return BadRequest("Problem setting main photo");



        }


        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
           
            var member = await uow.memberRepositry.GetUpdateMemberById(User.GetMemberId());

            if (member == null) return BadRequest("Cannot update member");

            var photo = member.Photo.FirstOrDefault(x => x.Id == photoId);

            if(photo == null) return NotFound();

            if(photo.PublicId != null)
            {
                var result= await photoService.DeletePhotoAsync(photo.PublicId);
                if(result.Error != null) return BadRequest(result.Error.Message);
            }

            member.Photo.Remove(photo);
            if (await uow.Complete()) return NoContent();

            return BadRequest("Problem deleting photo");
           

        }

    };

}
