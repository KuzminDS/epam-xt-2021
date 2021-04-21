using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Entities
{
    public enum ChangeMode
    {
        None,
        Difference,
        Added,
        Deleted,
        Renamed
    }
}
