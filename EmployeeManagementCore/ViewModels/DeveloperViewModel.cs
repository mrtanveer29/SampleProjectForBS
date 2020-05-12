
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCore.ViewModels
{
    public class DeveloperViewModel 
    {
        [Display(Name ="Problem Solved")]
        public int SolveCount { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string DeveloperName { get; set; }
        [Display(Name ="Type")]
        public int DeveloperType { get; set; }
        [Display(Name = "Rating")]
        public int DeveloperRating { get; set; }

        public int DeveloperId { get; set; }

        [Display(Name = "Developer Type")]
        public string DeveloperTypeName { get; set; }
        public string Products { get; set; }
        public string Components { get; set; }
        [Display(Name ="Platforms/Hardware")]
        public string Platforms { get; set; }
        [Display(Name = "Keywords/Vocabulary")]
        public string Skills { get; set; }
        [Display(Name = "Prevous Works/Profile Link")]
        public string PreviousWorks { get; set; }

  

    }
}
