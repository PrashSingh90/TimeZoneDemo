﻿using Guest_BO.DataModel;
using Guest_DAL.Data;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_DAL.Repository
{
    public class GuestPhoneNumberRepository : Repository<GuestPhoneNumber>, IGuestPhoneNumberRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestPhoneNumberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
