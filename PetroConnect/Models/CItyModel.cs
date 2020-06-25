using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class CityModel
    {
        public int CTM_STM_StateID { get; set; }
        public string CTM_Name { get; set; }
        public int CTM_CityCode { get; set; }
    }


    public class StateModel
    {
        public int STM_StateId { get; set; }
        public string STM_Name { get; set; }
        public int STM_CNM_CountryId { get; set; }
    }
}
