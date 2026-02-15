using System;
using API.DTOs;
using API.Helpers;
using API.Intities;

namespace API.Interfaces;

public interface IMessageRepository
{
 void  AddMessage(Message message);

 void DeleteMessage(Message message);

 Task <Message?> GetMessage(string messageId);
 
 Task<PaginatedHelpers<MessageDto>> GetMessagesForMember(MessageParams messageParams);

 Task<IReadOnlyList<MessageDto>> GetMessageThread(string currentMemberId, string recipientMemberId);


}
