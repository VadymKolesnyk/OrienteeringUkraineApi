using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Infrastructure.Models
{
    public class ErrorResponse
    {
        public ICollection<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
