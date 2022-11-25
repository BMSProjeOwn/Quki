﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IProductWithAttributeStaticValueRepository : IGenericRepository<ProductWithAttributeStaticValue>   
    {
        public ProductWithAttributeStaticValue GetProductAttiributeStaticValue(int productSeqID, int attributeStaticValueSeqID);       
    }
}