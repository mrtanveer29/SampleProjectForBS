using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessWithRepository.Model
{
    public class Comment
    {
        [Key]
        public int comment_id { get; set; }
        public int post_id { get; set; }
        public string comment { get; set; }
        public string user_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
