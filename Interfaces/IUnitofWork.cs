using System;
using API.AppData;

namespace API.Interfaces;

public interface IUnitofWork
{
    IMemberRepositry memberRepositry { get; }

    IMessageRepository messageRepository { get; }

    ILikeMemberRepository likedMemberRepository { get; }

    Task<bool> Complete();

    bool hasChanges();
}
