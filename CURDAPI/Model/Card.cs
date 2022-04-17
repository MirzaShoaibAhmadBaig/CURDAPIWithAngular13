using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CURDAPI.Model
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardHolderName { get; set; }
        public string PhoneNum { get; set; }
        public string Gender { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }

        public int CVC { get; set; }
    }
}
