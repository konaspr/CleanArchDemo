using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CourseViewModel courseViewModel)
        {
            _courseService.CreateCourse(courseViewModel);

            return Ok(courseViewModel);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] CourseViewModel courseViewModel)
        {
            _courseService.UpdateCourse(courseViewModel);

            return Ok(courseViewModel);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] CourseViewModel courseViewModel)
        {
            _courseService.DeleteCourse(courseViewModel.Id);

            return Ok();
        }
    }
}
