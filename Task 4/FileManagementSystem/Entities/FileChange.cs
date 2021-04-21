using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Entities
{
    public class FileChange
    {
        public string Path { get; set; }

        public ChangeMode ChangeMode { get; set; }

        public List<TextChange> TextChanges { get; set; }
    }
}
