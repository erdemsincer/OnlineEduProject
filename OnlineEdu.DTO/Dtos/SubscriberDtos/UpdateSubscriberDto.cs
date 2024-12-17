using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.Dtos.SubscriberDtos
{
    public class UpdateSubscriberDto
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
