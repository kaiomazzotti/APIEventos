using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Entity
{
    public class CityEventEntity
    {
        [Key]
        public long IdEvent { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateHourEvent { get; set; }
        [Required]
        public string Local { get; set; }
        public string Address { get; set; }
        public Decimal Price { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
