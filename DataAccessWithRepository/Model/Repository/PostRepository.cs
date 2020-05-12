using DataAccess.Models;

using DataAccessWithRepository.Model.IRepository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessWithRepository.Model.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {

        public PostRepository(BugTriageContext context):base(context)
        {

        }
      
        public BugTriageContext BugTriageContext { get { return context as BugTriageContext; } }

        public object GetPostWithComment(int page, string query)
        {
            var posts = (from post in BugTriageContext.Posts
                        join us in BugTriageContext.Users on post.user_id equals us.Id
                        select new
                        {
                            post.post,
                            post.post_data,
                            post.post_time,
                            post.user_id,
                            us.UserName,
                            comments = (from com in BugTriageContext.Comments.Where(x => x.post_id == post.post_id)
                                         join usc in BugTriageContext.Users on com.user_id equals usc.Id
                                         select new
                                         {
                                             com.comment,
                                             usc.UserName,
                                             com.comment_id,
                                             com.date,
                                             com.time,
                                             like=(from r in BugTriageContext.CommentReactions.Where(x=>x.commernt_id==com.comment_id && x.like==true) select r.like).Count(),
                                             dislike=(from r in BugTriageContext.CommentReactions.Where(x=>x.commernt_id==com.comment_id && x.dislike==true) select r.like).Count(),
                                         })
                        }).ToList();
            if (page > 0) {
                return posts.Take(3).Skip(page * 3).ToList(); // assuming page size is 3
            }
            if (query != null) {
                return posts.Where(x => x.post == query);
            }
            return posts;

        }
    }
}
