﻿using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Model.Entities;

namespace QuanLyKho.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppsDbContext context) : base(context)
        {
        }
    }
}