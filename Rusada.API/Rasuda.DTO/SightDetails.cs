using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rasuda.DTO
{
    public class SightDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Registration { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime SightDate { get; set; }
        public string PhotoFileName { get; set; }

    }
}
