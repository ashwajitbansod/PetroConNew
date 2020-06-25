using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class GlobalCodeModel
    {
        public long GBC_Code { get; set; }
        public string GBC_Category { get; set; }
        public string GBC_CodeName { get; set; }
        public string GBC_Description { get; set; }
        public int GBC_SortOrder { get; set; }
    }
}
