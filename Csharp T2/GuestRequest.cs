using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_T2
{
    class GuestRequest
    {
        public
        DateTime EntryDate;
        DateTime ReleaseDate;
        bool IsApproved;
        public override string ToString()
        {
            return EntryDate.ToString("DD/MM/YY") + " " + ReleaseDate.ToString("DD/MM/YY");
        }

    }
}
