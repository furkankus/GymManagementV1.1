using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string name, object key = null) : base($"Entity {name} {key} was not found.")
        {

        }
    }
}
