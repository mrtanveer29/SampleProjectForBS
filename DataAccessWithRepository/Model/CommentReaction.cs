using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessWithRepository.Model
{
    public class CommentReaction
    {
        [Key]
        public int react_id { get; set; }
        public int commernt_id { get; set; }
        public string user_id { get; set; }
        public bool like { get; set; }
        public bool dislike { get; set; }
    }
}
