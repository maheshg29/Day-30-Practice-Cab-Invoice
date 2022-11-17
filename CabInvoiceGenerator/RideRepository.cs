using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
       
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();

        }
        public void AddRide(string userID, Ride[] rides)
        {
            bool ridelist=this.userRides.ContainsKey(userID);
            try
            {
                if (!ridelist)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID, list);
                }
            }
            catch(CabInvoiceException) 
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Null Ride");
            }
        }

        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USERID, "Invalid User ID");
            }
        }
    }
}
