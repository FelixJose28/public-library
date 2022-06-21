﻿using Library.Core.Interfaces;
using Library.Core.Models.Entities;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookStatusRepository:GenericRepository<BookStatus>, IBookStatusRepository
    {
        public BookStatusRepository(DBLibraryContext context) : base(context)
        {

        }
    }
}
