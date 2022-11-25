﻿using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class RvcMenuItemPriceRepository : GenericRepository<RvcMenuItemPrice>,IRvcMenuItemPriceRepository
    {
        public RvcMenuItemPriceRepository(DbContext context) : base(context)
        {

        }
    }
}