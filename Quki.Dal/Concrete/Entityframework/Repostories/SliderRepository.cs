using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class SliderRepository: GenericRepository<Slider>,ISliderRepository
    {
        public SliderRepository(DbContext context) : base(context)
        {
        }

    }
}
