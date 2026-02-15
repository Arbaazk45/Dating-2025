using System;
using System.Data.Common;
using API.Interfaces;

namespace API.AppData;

public class UnitOfWork(AppDbContext context) : IUnitofWork
{

    private IMemberRepositry? _memberRepositry;
    private IMessageRepository? _messageRepository;
    private ILikeMemberRepository? _likedMemberRepository;

    public IMemberRepositry memberRepositry => _memberRepositry ??= new MemberRepositry(context);

    public IMessageRepository messageRepository => _messageRepository ??= new MessageRepository(context);

    public ILikeMemberRepository likedMemberRepository => _likedMemberRepository ??= new LikedMemberRepository(context);

    public async Task<bool> Complete()
    {
        try
        {
          return await context.SaveChangesAsync() > 0;
        }
        catch (DbException ex)
        {
            
           throw new Exception("Error saving changes", ex);
        }
    }

    public bool hasChanges()
    {
        return context.ChangeTracker.HasChanges();
    }
}
