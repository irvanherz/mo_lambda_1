using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class DataSecUser
    {
        public List<string> FormArray { get; set; } = new List<string>();
        public List<string> ParentArray { get; set; } = new List<string>();
    }
}