using DataAccess.Models;
using DataAccessWithRepository.Model.IRepository;
using DataAccessWithRepository.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessWithRepository.Model
{
    public class UnitOfWork : IUnitOfWork
    {
        public BugTriageContext Context;
        public IPostRepository Posts { get; private set; }
        public UnitOfWork(BugTriageContext context)
        {
            Context = context;
            Posts = new PostRepository(context);
        }


       

        public int Complete()
        {
           return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
