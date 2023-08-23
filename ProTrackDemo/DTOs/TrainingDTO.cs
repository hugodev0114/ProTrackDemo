using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTrackDemo.DTOs
{
    public class TrainingDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
