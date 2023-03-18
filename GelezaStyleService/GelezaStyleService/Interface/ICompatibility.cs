using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Interface
{
    interface ICompatibility
    {
        public int CreateCompatibility(Compatibility compatibility);

        //Needs attention
        public IEnumerable<Compatibility> GetCompatibility(int itemID);
        //public IEnumerable<Compatibility> GetCompatibilities();

        public int DeleteCompatibility(Compatibility compatibility);
    }
}
