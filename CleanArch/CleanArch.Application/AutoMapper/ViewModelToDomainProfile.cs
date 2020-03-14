using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CourseViewModel, CreateCourseCommand>()
                .ConvertUsing(c => new CreateCourseCommand(c.Name, c.Description, c.ImageUrl));

            CreateMap<CourseViewModel, UpdateCourseCommand>()
                .ConvertUsing(c => new UpdateCourseCommand(c.Id, c.Name, c.Description, c.ImageUrl));
        }
    }
}
