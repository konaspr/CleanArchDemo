using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourses();

        void CreateCourse(CourseViewModel courseViewModel);

        void UpdateCourse(CourseViewModel courseViewModel);

        void DeleteCourse(int id);
    }
}
