using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Application.Infrastructure.Models
{
    public class ItemsCollection<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}
