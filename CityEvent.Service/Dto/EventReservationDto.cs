using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Dto
{
    public class EventReservationDto
    {
        [Required(ErrorMessage = "Identificação do evento é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "Precisa informar um numero inteiro nao nulo ")]
        public long IdEvent { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string personName { get; set; }
        [Required(ErrorMessage = "Quantidade de reservas obrigatório!")]

        public long Quantity { get; set; }
    }
}
