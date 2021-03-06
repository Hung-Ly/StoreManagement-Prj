﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QuanLyKho.Data.Infrastructure
{
    public static class Extensions
    {
        public static T Find<T>(this DbSet<T> set, params object[] keyValues) where T : class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<DbContext>();

            var entityType = context.Model.FindEntityType(typeof(T));
            var key = entityType.FindPrimaryKey();

            var entries = context.ChangeTracker.Entries<T>();

            var i = 0;
            foreach (var property in key.Properties)
            {
                entries = Enumerable.Where(entries, e => e.Property(property.Name).CurrentValue == keyValues[i]);
                i++;
            }

            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }

            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(T), "x");
            var query = Queryable.Where(set, (Expression<Func<T, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, "Id"),
                        Expression.Constant(keyValues[0])),
                    parameter));

            // Look in the database
            return query.FirstOrDefault();
        }
    }
}