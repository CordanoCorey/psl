using AutoMapper;
using psl.API.Infrastructure;
using psl.Entity.Context;
using psl.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Products
{
    public interface IProductsRepository : IBaseRepository<Product, ProductModel>
    {
    }

    public class ProductsRepository : BaseRepository<PSLContext, Product, ProductModel>, IProductsRepository
    {
        public ProductsRepository(PSLContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
