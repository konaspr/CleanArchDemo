using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDBContext _ctx;

        public CourseRepository(UniversityDBContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Course course)
        {
            _ctx.Courses.Add(course);
            _ctx.SaveChanges();
        }

        public void Update(Course course)
        {
            var courseDbSet = _ctx.Courses.Find(course.Id);

            if (courseDbSet == null)
                throw new KeyNotFoundException();

            courseDbSet.Name = course.Name;
            courseDbSet.Description = course.Description;
            courseDbSet.ImageUrl = course.ImageUrl;

            _ctx.SaveChanges();            
        }

        public void Delete(int id)
        {
            var courseDbSet = _ctx.Courses.Find(id);

            if (courseDbSet == null)
                throw new KeyNotFoundException();

            _ctx.Courses.Remove(courseDbSet);
            _ctx.SaveChanges();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _ctx.Courses;
        }
    }
}
