using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Commands
{
    public class DeleteCourseCommand : CourseCommand
    {
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
