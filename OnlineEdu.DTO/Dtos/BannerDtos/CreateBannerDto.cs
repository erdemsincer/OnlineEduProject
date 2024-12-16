using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.Dtos.BannerDtos
{
    public class CreateBannerDto
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
