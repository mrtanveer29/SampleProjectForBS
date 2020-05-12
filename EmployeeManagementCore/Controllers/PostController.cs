using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccessWithRepository.Model;
using DataAccessWithRepository.Model.IRepository;
using EmployeeManagementCore.Utils;
using EmployeeManagementCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace EmployeeManagementCore.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IHostingEnvironment environment;
        private readonly BugTriageContext context;
        private readonly UnitOfWork unitOfWork;

        public PostController(IPostRepository postRepository, IHostingEnvironment environment, BugTriageContext context)
        {
            this.postRepository = postRepository;
            this.environment = environment;
            this.unitOfWork = new UnitOfWork(context);
        }
       

        [Route("/")]
        public IActionResult Create()
        {
           
            return View();
        }
      
        public IActionResult ViewPosts()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(PostViewModel postData)
        {
            if (ModelState.IsValid) {
                Post posts = new Post
                {
                    post = postData.post,
                    post_data = DateTime.Now.ToString("dd/MM/yyyy"),
                    post_time = DateTime.Now.ToString("hh:tt:ss"),
                    user_id = postData.user_id

                };
                unitOfWork.Posts.Add(posts);
                unitOfWork.Complete();
            }
           
            return View(postData);
        }

        public IActionResult GetPost(int page=0, string query=null) {
            var posts=postRepository.GetPostWithComment(page, query);
            return Json(posts);
        }


    }
}