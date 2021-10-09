using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repo
{
    public class ClaimRepo
    {
        private Queue<Claim> claimsQueue = new Queue<Claim>();
        //Create
        public bool AddClaimsToList(Claim claim)
        {
            int initialCount = claimsQueue.Count;
            claimsQueue.Enqueue(claim);
            if(initialCount < claimsQueue.Count)
            {
                return true;
            }
            return false;
        }
        //Read
        public Queue<Claim> DisplayListOfClaims()
        {
            return claimsQueue;
        }
        ////Update
        //public void UpdateClaimInList(int id, Claim newClaim)
        //{
        //    Claim oldClaim = GetClaimByID(id);
        //    if(oldClaim.Id == id)
        //    {
        //        oldClaim.Id = newClaim.Id;
        //        oldClaim.Type = newClaim.Type;
        //        oldClaim.Description = newClaim.Description;
        //        oldClaim.Amount = newClaim.Amount;
        //        oldClaim.IncidentDate = newClaim.IncidentDate;
        //        oldClaim.ClaimDate = newClaim.ClaimDate;
        //        oldClaim.IsValid = newClaim.IsValid;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Unable to update, ID not found.");
        //    }
        //}
        ////Delete
        //public bool DeleteClaimFromList(int id)
        //{
        //   Claim claim = GetClaimByID(id);
        //    if (claim == null)
        //    {
        //        return false;
        //    }
        //    int initialCount = claimsQueue.Count;
        //    claimsQueue.Dequeue();
        //    if(initialCount > claimsQueue.Count)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //Helper Method
        public Claim GetClaimByID(int id)
        {
            foreach(Claim claim in claimsQueue)
            {
                if (claim.Id == id)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
