using System;
using API.Helpers;
using API.Interfaces;
using API.Intities;
using Microsoft.EntityFrameworkCore;

namespace API.AppData;

public class MemberRepositry(AppDbContext context) : IMemberRepositry
{
    public async Task<PaginatedHelpers<Members>> GetAllAsync(MemberParams memberParams)
    {
        var query = context.members.AsQueryable();

        query = query.Where(X => X.Id != memberParams.CurrentMemberId);
        if (memberParams.Gender != null)
        {
            query = query.Where(X => X.Gender == memberParams.Gender);
        }

        var MinAge = DateOnly.FromDateTime(DateTime.Today.AddYears(-memberParams.MaxAge - 1));
        var MaxAge = DateOnly.FromDateTime(DateTime.Today.AddYears(-memberParams.MinAge));
        query = query.Where(X => X.DateOfBirth >= MinAge && X.DateOfBirth <= MaxAge);

        query = memberParams.SortedBy switch
        {
            "created" => query.OrderByDescending(x => x.Created),
            _ => query.OrderByDescending(x => x.LastActive)
        };

        return await PaginationFunction.CreateAsync(query,
        memberParams.PageNumber, memberParams.PageSize);

    }

    public async Task<Members?> GetMemberByIdAsync(string id)
    {
        return await context.members.FindAsync(id);
    }

    public Task<Members?> GetUpdateMemberById(string id)
    {
        return context.members.
        Include(x => x.User).
        Include(x => x.Photo).
        SingleOrDefaultAsync(x => x.Id == id);
    }


    public void update(Members member)
    {
        context.Entry(member).State = EntityState.Modified;
    }


    public async Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId, bool isCurrentUser)
    {
        var query = context.members
            .Where(x => x.Id == memberId)
            .SelectMany(x => x.Photo);

        if (isCurrentUser) query = query.IgnoreQueryFilters();

        return await query.ToListAsync();
    }

}
