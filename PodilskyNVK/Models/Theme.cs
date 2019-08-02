using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PodilskyNVK.Models
{
    public class Theme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядку має бути від 3 до 50 символів")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Theme()
        {
            Posts = new List<Post>();
        }
    }
}