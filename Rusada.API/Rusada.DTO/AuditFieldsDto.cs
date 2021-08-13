using System;
using System.Collections.Generic;
using System.Text;

namespace Rusada.DTO
{
    public class AuditFieldsDto
    {
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
