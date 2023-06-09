﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("CATEGORY_82CART")]
    public class CATEGORY_82CART
    {
        [StringLength(50)]
        public string ID_CATEGORY { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(50)]
        public string ID_PARENT { get; set; }

        [StringLength(10)]
        public string LEVEL_DEPTH { get; set; }

        [StringLength(10)]
        public string POSITION { get; set; }

        [StringLength(1)]
        public string ACTIVE { get; set; }

        [StringLength(100)]
        public string ACCOUNT { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecNum { get; set; }
    }
}