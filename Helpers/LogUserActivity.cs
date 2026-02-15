using System;
using API.AppData;
using API.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers;

public class LogUserActivity : IAsyncAlwaysRunResultFilter
{

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = await  next();

        if(result.HttpContext.User.Identity.IsAuthenticated)
        {
            var memberId = context.HttpContext.User.GetMemberId();

            var user =  result.HttpContext.RequestServices.GetRequiredService<AppDbContext>();

          await user.members.Where(x => x.Id == memberId)
          .ExecuteUpdateAsync(x=>x.SetProperty(
            m=>m.LastActive, m=>DateTime.UtcNow));
        }


    }
}
