using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_T2
{
    public class Host: IEnumerable
    {
        public int HostKey;
        public List<HostingUnit> HostingUnitCollection = new List<HostingUnit>();

        public Host(int id, int numOfRooms)
        {
            HostKey = id;
            for (int i=0; i< numOfRooms; i++ )
            {
                HostingUnit newUnit = new HostingUnit();
                HostingUnitCollection.Add(newUnit);
            }


        }
        public override string ToString()
        {
            string output = " ";

            for(int i=0;i< this.HostingUnitCollection.Count;i++)
            {
                output += this.HostingUnitCollection[i].ToString();
            }
            return output;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
           
            foreach(var unit in HostingUnitCollection)
                if (unit.ApproveRequest(guestReq) == true)
                    return unit.HostingUnitKey;
             return -1;

        }




















    }
}
