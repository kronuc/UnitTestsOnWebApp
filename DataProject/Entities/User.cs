using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Entities
{
    public class User: BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
