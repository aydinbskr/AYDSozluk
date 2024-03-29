﻿using AYDSozluk.Common.Models.Page;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Infrastructure.Extensions
{
    public static class PagingExtensions
    {

        public static async Task<PagedResponse<T>> GetPaged<T>(this IQueryable<T> query,
                                                                int currentPage,
                                                                int pageSize) where T : class
        {
            var count = await query.CountAsync();

            Page paging = new(currentPage, pageSize, count);

            var data = await query.Skip(paging.Skip).Take(paging.PageSize).AsNoTracking().ToListAsync();

            var result = new PagedResponse<T>(data, paging);

            return result;
        }

    }
}
