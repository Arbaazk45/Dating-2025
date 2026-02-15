using System;
using API.DTOs;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using API.Intities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MessageController(IUnitofWork uow) : BaseController
{
    [HttpPost]

    public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
    {


        var sender = await uow.memberRepositry.GetMemberByIdAsync(User.GetMemberId());
        var receiver = await uow.memberRepositry.GetMemberByIdAsync(createMessageDto.RecieverId);

        if (sender == null || receiver == null || sender.Id == receiver.Id) return BadRequest("Invalid member id");

        var message = new Message
        {
            SenderId = sender.Id,
            RecieverId = receiver.Id,
            Content = createMessageDto.Content
        };

        uow.messageRepository.AddMessage(message);
        if (await uow.Complete()) return message.ToDto();

        return BadRequest("Problem adding message");
    }

    [HttpGet]

    public async Task<ActionResult<PaginatedHelpers<MessageDto>>> GetMessages([FromQuery] MessageParams messageParams)
    {
         messageParams.MemberId = User.GetMemberId();
       return await uow.messageRepository.GetMessagesForMember(messageParams);

    }


[HttpGet("thread{recipientMemberId}")]

public async Task<ActionResult<IReadOnlyList<MessageDto>>> GetMessageThread(string recipientMemberId)
    {
        return Ok(await uow.messageRepository.GetMessageThread(User.GetMemberId(), recipientMemberId));
    }
}
