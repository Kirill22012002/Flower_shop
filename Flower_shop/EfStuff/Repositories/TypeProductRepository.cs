﻿using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower_shop.EfStuff.Repositories
{
    public class TypeProductRepository : BaseRepository<TypeProduct>
    {
        public TypeProductRepository(WebDbContext context) : base(context)
        {
        }
        public TypeProduct GetByName(string name)
        {
            return _webContext.TypesProduct.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
