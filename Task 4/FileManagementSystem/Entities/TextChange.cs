using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Entities
{
    public class TextChange
    {
        public ChangeMode ChangeMode { get; set; }

        public int LineNumber { get; set; }

        public string PreviousText { get; set; }

        public string NewText { get; set; }
    }
}
