﻿using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.Dtos.CourseVideoDtos
{
    public class UpdateCourseVideoDto
    {
        public int CourseId { get; set; }
        
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
