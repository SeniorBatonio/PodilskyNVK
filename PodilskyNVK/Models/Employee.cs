using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PodilskyNVK.Models
{
    public enum EmployeeRole
    {
        Administration,
        Teacher
    }

    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле має бути заповненим")]
        [Display(Name = "ПІБ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле має бути заповненим")]
        [Display(Name = "Про робітника")]
        public string AboutEmploee { get; set; }
        public byte[] Photo { get; set; }
        [Required(ErrorMessage = "Поле має бути заповненим")]
        [Display(Name = "Позиція робітника")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Поле має бути заповненим")]
        [Display(Name = "Роль робітника")]
        public EmployeeRole Role { get; set; }
    }
}