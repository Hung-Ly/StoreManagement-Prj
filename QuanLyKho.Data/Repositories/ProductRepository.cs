﻿using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppsDbContext context) : base(context)
        {
        }
    }
}