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
        void AddEmployee(Employee employee);
        void AddPhoto(Photo photo);
        void AddPhotos(IEnumerable<Photo> photos);

        void SavePost(Post post);
        void SaveEmployee(Employee employee);

        IEnumerable<Post> PostsList();
        IEnumerable<Theme> ThemesList();
        IEnumerable<Employee> EmployeesList();
        IEnumerable<Photo> PhotoList();

        Post GetPost(int id);
        Theme GetTheme(int id);
        Employee GetEmployee(int id);

        void DeletePost(int id);
        void DeleteEmployee(int id);
        void DeletePhoto(int id);
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

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void AddPhoto(Photo photo)
        {
            db.Photos.Add(photo);
            db.SaveChanges();
        }

        public IEnumerable<Photo> PhotoList()
        {
            return db.Photos.ToList();
        }

        public void AddPhotos(IEnumerable<Photo> photos)
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

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }

        public void SaveEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = new Employee { Id = id }; 
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeletePhoto(int id)
        {
            Photo photo = new Photo { Id = id };
            db.Entry(photo).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }

}