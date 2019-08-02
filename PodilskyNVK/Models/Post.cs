using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PodilskyNVK.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядку має бути від 3 до 50 символів")]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлено")]
        [StringLength(Int32.MaxValue, MinimumLength = 3, ErrorMessage = "Довжина рядку має бути від 3 до 50 символів")]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDateTime { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }

        public Post()
        {
            Photos = new List<Photo>();
            Themes = new List<Theme>();
        }
    }

    public class Photo
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Post Post { get; set; }
    }
}