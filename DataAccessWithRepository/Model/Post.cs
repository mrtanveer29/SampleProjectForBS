using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessWithRepository.Model
{
    public class Post
    {
        [Key]
        public int post_id { get; set; }
        public string post { get; set; }
        public string post_data { get; set; }
        public string post_time { get; set; }
        public string user_id { get; set; }
    }
}
