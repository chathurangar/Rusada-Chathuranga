using System;
using System.Collections.Generic;
using System.Text;

namespace Rusada.DTO
{
    public class SightDetailsDto : AuditFieldsDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime SightDate { get; set; }
        public string PhotoFileName { get; set; }
    }
}
