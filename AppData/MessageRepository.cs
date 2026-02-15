using System;
using API.DTOs;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using API.Intities;
using Microsoft.EntityFrameworkCore;

namespace API.AppData;

public class MessageRepository(AppDbContext context) : IMessageRepository
{
    public void AddMessage(Message message)
    {
        context.messages.Add(message);
    }

    public void DeleteMessage(Message message)
    {
        context.messages.Remove(message);
    }

    public async Task<Message?> GetMessage(string messageId)
    {
        return await context.messages.FindAsync(messageId);
    }

    public async Task<PaginatedHelpers<MessageDto>> GetMessagesForMember(MessageParams messageParams)
    {
        var query = context.messages.OrderByDescending(x => x.MessageSent).AsQueryable();
        query = messageParams.Container switch
        {
            "Outbox" => query.Where(x => x.SenderId == messageParams.MemberId),
            _ => query.Where(x => x.RecieverId == messageParams.MemberId),

        };
        var messageQuery = query.Select(MessageExtensions.ToDtoExpression());
        return await PaginationFunction.CreateAsync(messageQuery, messageParams.PageNumber, messageParams.PageSize);
    }

    public async Task<IReadOnlyList<MessageDto>> GetMessageThread(string currentMemberId, string recipientMemberId)
    {
        await context.messages.Where(x => x.SenderId == recipientMemberId && x.RecieverId == currentMemberId).
        ExecuteUpdateAsync(setters => setters.SetProperty(x => x.DateRead, DateTime.UtcNow));

        return await context.messages
     .Where(x =>
         (x.SenderId == currentMemberId && x.RecieverId == recipientMemberId) ||
         (x.SenderId == recipientMemberId && x.RecieverId == currentMemberId)
     )
     .OrderBy(x => x.MessageSent)
     .Select(MessageExtensions.ToDtoExpression())
     .ToListAsync();

    }

}
