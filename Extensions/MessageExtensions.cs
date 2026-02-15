using System;
using System.Linq.Expressions;
using API.DTOs;
using API.Intities;

namespace API.Extensions;

public static class MessageExtensions
{
 public static MessageDto ToDto(this Message message)
    {
       return new MessageDto
        {
            Id = message.Id,
            SenderId = message.SenderId,
            SenderDisplayName = message.Sender.DisplayName,
            SenderImageUrl = message.Sender.ImageUrl,
            RecieverId = message.RecieverId,
            RecieverDisplayName = message.Reciever.DisplayName,
            RecieverImageUrl = message.Reciever.ImageUrl,
            Content = message.Content,
            MessageSent = message.MessageSent,
            DateRead = message.DateRead ?? DateTime.UtcNow
        };
        
    }

    public static Expression<Func<Message,MessageDto>> ToDtoExpression()
    
    {
        return message=>new MessageDto
        {
            Id = message.Id,
            SenderId = message.SenderId,
            SenderDisplayName = message.Sender.DisplayName,
            SenderImageUrl = message.Sender.ImageUrl,
            RecieverId = message.RecieverId,
            RecieverDisplayName = message.Reciever.DisplayName,
            RecieverImageUrl = message.Reciever.ImageUrl,
            Content = message.Content,
            MessageSent = message.MessageSent,
            DateRead = message.DateRead ?? DateTime.UtcNow
        };
    }
}
