using DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessWithRepository.Model.IRepository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        object GetPostWithComment(int page, string query);
    }
}
