using System;
using API.Helpers;
using API.Intities;

namespace API.Interfaces;

public interface IMemberRepositry
{
 void update(Members member);


  Task<PaginatedHelpers<Members>> GetAllAsync(MemberParams memberParams);

  Task<Members?> GetMemberByIdAsync(string id);

  Task<Members?> GetUpdateMemberById(string id);

   Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId, bool isCurrentUser);

}
