using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class PlaceHolderModel
    {
        public long UID_UserId_Owner { get; set; }
        public long UID_UserId_Customer { get; set; }
        public DataTable UT_SaleBucket { get; set; } /**STSTUS P:Place Order/ C:Confirm Order / R:Reject Order**/
    }
}
