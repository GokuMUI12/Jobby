using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class OfferToReturnDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Days { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }
    }
}
