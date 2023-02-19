using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Entity
{
    public class EventReservationEntity
    {
        [Key]
        public long IdReservation { get; set; }

        [Required]
        [ForeignKey("IdEvent")]
        public long IdEvent { get; set; }

        [Required]
        public string PersonName { get; set; }

        [Required]
        public long Quantity { get; set; }
    }
}
