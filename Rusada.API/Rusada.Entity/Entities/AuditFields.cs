using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rusada.Entity.Entities
{
    public class AuditFields
    {
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
