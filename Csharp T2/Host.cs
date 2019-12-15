using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_T2
{
    public class Host : IEnumerable
    {
        public int HostKey;
        public List<HostingUnit> HostingUnitCollection = new List<HostingUnit>();

        public Host(int id, int numOfRooms)
        {
            HostKey = id;
            for (int i = 0; i < numOfRooms; i++)
            {
                HostingUnit newUnit = new HostingUnit();
                HostingUnitCollection.Add(newUnit);
            }


        }
        public override string ToString()
        {
            string output = " ";

            for (int i = 0; i < this.HostingUnitCollection.Count; i++)
            {
                output += this.HostingUnitCollection[i].ToString();
            }
            return output;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {

            foreach (var unit in HostingUnitCollection)
                if (unit.ApproveRequest(guestReq) == true)
                    return unit.HostingUnitKey;
            return -1;

        }
        public int GetHostAnnualBusyDays()
        {
            int counter = 0;

            foreach (var unit in HostingUnitCollection)
                counter += unit.GetAnnualBusyDays();
            return counter;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (SubmitRequest(list[i]) == -1)
                    return false;
            }
            return true;
        }

        public HostingUnit this[int i]
        {
            get
            {
                if (this.HostingUnitCollection[i] != null)
                    return this.HostingUnitCollection[i];
                else
                    return null;
            }
            set
            {
                this.HostingUnitCollection[i] = value;
            }
        }

        public IEnumerator GetEnumerator()

        {
            for (int i = 0; i < HostingUnitCollection.Count; i++)
                yield return HostingUnitCollection[i];
        }
    }
}


