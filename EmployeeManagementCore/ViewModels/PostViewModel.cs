using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementCore.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public int post_id { get; set; }
        [Required]
        [Display(Name = "Create a post")]
        public string post { get; set; }
        public string post_data { get; set; }
        public string post_time { get; set; }
        public string user_id { get; set; }
    }
}
