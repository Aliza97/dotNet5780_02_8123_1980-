using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_T2
{
    class HostingUnit : IComparable
    {
        private static int stSerialKey;
        public long HostingUnitKey;
        bool[,] Diary = new bool[12, 31];
        public override string ToString()// print the unit number and the dates of beginning and ending of the reservation
        {
            string output = "Unit Number:" + stSerialKey + "Dates:";
            int helpI = 0 ,helpJ = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {
                    helpI = i;
                    helpJ = j;

                    if (Diary[i, j] == true && Diary[i, j - 1] == false && j != 0)
                    {
                        output += i + 1 + "/" + j + 1 + "/2020-";
                    }

                    if (Diary[i, j]== true &&  Diary[i - 1, 30]== false && j == 0)
                    {
                        output += i + 1 + "/" + j + 1 + "/2020-";
                    }

                    if (Diary[0, 0] == true)
                    {
                        output += i + 1 + "/" + j + 1 + "/2020-";
                    }

                    if (Diary[i, j] == false && Diary[i, j - 1] == true && j != 0)
                    {
                        output += i + 1 + "/" + j + "/2020";
                    }

                    if (Diary[i, j] == false && j == 0 && Diary[i - 1, 30] == true)
                    {
                        output += i + "/" + 30 + "/2020";
                    }

                    if (Diary[11, 30] == true)
                    {
                        output += 11 + "/" + 30 + "/2020";
                    }
                    
                }
            return output;
        }

        public bool ApproveRequest(GuestRequest guestReq) // True if approved request false if not approved
        {


            if (guestReq.EntryDate.Month == guestReq.ReleaseDate.Month)
                for (int j = guestReq.EntryDate.Day; j < guestReq.ReleaseDate.Day - 1; j++)
                {
                    if (Diary[guestReq.ReleaseDate.Month, j] == false)

                        return guestReq.IsApproved = true;
                    else
                        return guestReq.IsApproved = false;
                }
            
            else
                for (int i = guestReq.EntryDate.Month; i < guestReq.ReleaseDate.Month; i++)
                    for (int j = guestReq.EntryDate.Day; j < guestReq.ReleaseDate.Day-1; j++)
                    {
                        if (Diary[i,j] == false)
                            return guestReq.IsApproved = true;
                        else
                            return guestReq.IsApproved = false;
                    }

            return guestReq.IsApproved;
        }

        
        public int GetAnnualBusyDays() // return all days taken in the year
        {
            int count = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    if (Diary[i, j] == false)
                        count++;
            return count;
        } 

        public float GetAnnualBusyPercentage()// print the pourcentage of taken days in year
        {
            int count = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    if (Diary[i, j] == false)
                        count++;
            float x = count*365/100;
            return x;

        } 
        int IComparable.CompareTo(object obj)
        {
            HostingUnit help = obj as HostingUnit;
            return Convert.ToInt32(this.GetAnnualBusyDays().CompareTo(help.GetAnnualBusyDays()));
        }
        public HostingUnit() //Constructor
        {
            HostingUnitKey = stSerialKey++;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    Diary[i, j] = false;
        }
            

    }
}
