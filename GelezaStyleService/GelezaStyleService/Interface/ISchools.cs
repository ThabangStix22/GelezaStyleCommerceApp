using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Interface
{
    interface ISchools
    {
        public int CreateSchool(Schools school);

        public Schools GetSchool(int Id);
        public IEnumerable<Schools> GetSchools();
        public IEnumerable<Schools> GetActiveSchool(int chActive);

        public int updateSchool(Schools updateSchool);
        public int DeleteSchool(int Id);
    }
}
