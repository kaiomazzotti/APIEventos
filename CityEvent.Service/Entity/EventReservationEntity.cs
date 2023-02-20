using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIEventos.Service.Interface;

namespace APIEventos.Service.Entity
{
    public class EventReservationEntity
    {


        public long IdEvent { get; set; }
        public string personName { get; set; }
        public long Quantity { get; set; }

    }
}
