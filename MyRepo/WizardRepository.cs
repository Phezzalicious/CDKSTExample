using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace MyRepo
{
    //where T : class is a promise that type T will be a class instance
    public class MyRepo<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public MyRepo(DbContext context){
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }

        
        
    }
}