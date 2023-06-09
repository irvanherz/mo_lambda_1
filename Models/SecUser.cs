using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("SecUser")]
    public class SecUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 RecNum { get; set; }

        [Required]
        public Int64? AccountId { get; set; }

        [Required]
        public Int64? UserId { get; set; }

        [Required]
        public Int32 FormId { get; set; }

        public Int32 ParentId { get; set; }

        public Boolean Permission { get; set; }
    }
}