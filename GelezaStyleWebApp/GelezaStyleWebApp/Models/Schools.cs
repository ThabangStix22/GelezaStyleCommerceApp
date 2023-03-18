using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Models
{
    public class Schools
    {

        public int SchID { get; set; }
        public string SchName { get; set; }
        public string SchAddress { get; set; }
        public int SchIsActive { get; set; }
        public int SchContactNo { get; set; }
        public string SchEmail { get; set; }
    }
}
