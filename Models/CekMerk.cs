using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class CekMerk
    {
        public bool Available { get; set; } = true;
        public string Kode { get; set; }
        public string Nama { get; set; }
    }
}