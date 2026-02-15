using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers;

public class PaginatedHelpers<T>
{
    public PaginatedMetaData metaData { get; set; } = default!;

    public List<T> Items { get; set; } = [];


}

public class PaginatedMetaData
{
    public int totalCount { get; set; }
    public int pageSize { get; set; }
    public int currentPage { get; set; }
    public int totalPages { get; set; }
}


public class PaginationFunction
{
    
    public static async Task<PaginatedHelpers<T>> CreateAsync<T>(IQueryable<T> query,
    int pageNumber, int pageSize)
    {
        var count = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedHelpers<T>
        {
            metaData = new PaginatedMetaData
            {
                totalCount = count,
                pageSize = pageSize,
                currentPage = pageNumber,
                totalPages = count / pageSize
            },
            Items = items
        };
    }
}
      




