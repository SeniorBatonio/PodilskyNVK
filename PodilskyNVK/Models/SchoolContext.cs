using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PodilskyNVK.Models
{
    public interface IRepository
    {
        void AddPost(Post post);
        void SavePost(Post post);
        void SaveEmployee(Employee employee);
        void SavePhoto(Photo photo);
        IEnumerable<Post> PostsList();
        IEnumerable<Theme> ThemesList();
        IEnumerable<Employee> EmployeesList();
        IEnumerable<Photo> PhotoList();
        Post GetPost(int id);
        Theme GetTheme(int id);
        void SavePhotos(IEnumerable<Photo> photos);
        void DeletePost(int id);
    }
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("DefaultConnection")
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Photo> Photos { get; set; }

    }

    public class Repository : IRepository, IDisposable
    {
        SchoolContext db = new SchoolContext();
        public Post GetPost(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> PostsList()
        {
            return db.Posts.ToList();
        }

        public IEnumerable<Employee> EmployeesList()
        {
            return db.Employees.ToList();
        }

        public void AddPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void SavePost(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
            
        }

        public IEnumerable<Theme> ThemesList()
        {
            return db.Themes.ToList().Where(t => t.Name != "Історія школи");
        }

        public Theme GetTheme(int id)
        {
            return db.Themes.Find(id);
        }

        public Employee GetEmploee(int id)
        {
            return db.Employees.Find(id);
        }

        public void SaveEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void SavePhoto(Photo photo)
        {
            db.Photos.Add(photo);
            db.SaveChanges();
        }

        public IEnumerable<Photo> PhotoList()
        {
            return db.Photos.ToList();
        }

        public void SavePhotos(IEnumerable<Photo> photos)
        {
            db.Photos.AddRange(photos);
            db.SaveChanges();
        }

        public void DeletePost(int id)
        {
            Post p = GetPost(id);
            if (p != null)
            {
                db.Photos.RemoveRange(p.Photos);
                db.Posts.Remove(p);
                db.SaveChanges();
            }
        }
    }

}