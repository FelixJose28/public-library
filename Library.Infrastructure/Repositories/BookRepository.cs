﻿using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository: GenericRepository<Book>,IBookRepository
    {
        private readonly DBLibraryContext _context;
        public BookRepository(DBLibraryContext context) : base(context)
        {
            _context = context;
        }
    }
}