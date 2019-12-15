using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_T2
{
    public class GuestRequest
    {
   
        public DateTime ReleaseDate;
        public DateTime EntryDate;
        public bool IsApproved;
        public override string ToString()
        {
            return EntryDate.ToString("DD/MM/YY") + " " + ReleaseDate.ToString("DD/MM/YY");
        }


    }

}
