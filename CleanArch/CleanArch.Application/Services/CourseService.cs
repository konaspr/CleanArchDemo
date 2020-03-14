using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper autoMapper)
        {
            _bus = bus;
            _autoMapper = autoMapper;
            _courseRepository = courseRepository;
        }

        public void CreateCourse(CourseViewModel courseViewModel)
        {
            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public void UpdateCourse(CourseViewModel courseViewModel)
        {
            _bus.SendCommand(_autoMapper.Map<UpdateCourseCommand>(courseViewModel));
        }

        public void DeleteCourse(int id)
        {
            _bus.SendCommand(new DeleteCourseCommand(id));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _courseRepository.GetCourses()
                .ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
