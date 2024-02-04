using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class OfferToCreateDto
    {
        public int Amount { get; set; }
        public int DaysExpected { get; set; }
        public int JobId { get; set; }
        public string Message { get; set; }
    }
}
