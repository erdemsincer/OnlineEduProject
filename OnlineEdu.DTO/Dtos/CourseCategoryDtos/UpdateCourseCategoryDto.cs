﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.Dtos.CourseCategoryDtos
{
    public class UpdateCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
    }
}