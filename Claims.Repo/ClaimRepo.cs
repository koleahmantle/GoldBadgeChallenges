using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repo
{
    public class ClaimRepo
    {
        private List<Claims> _listOfClaims = new List<Claims>();
        //Create
        public void AddClaimsToList(Claims claim)
        {
            _listOfClaims.Add(claim);
        }
        //Read
        public List<Claims> DisplayListOfClaims()
        {
            return _listOfClaims;
        }
        //Update
        public void UpdateClaimInList(int id, Claims newClaim)
        {
            Claims oldClaim = GetClaimByID(id);
            if(oldClaim.Id == id)
            {
                oldClaim.Id = newClaim.Id;
                oldClaim.Type = newClaim.Type;
                oldClaim.Description = newClaim.Description;
                oldClaim.Amount = newClaim.Amount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;
            }
            else
            {
                Console.WriteLine("Unable to update, ID not found.");
            }
        }
        //Delete
        public bool DeleteClaimFromList(int id)
        {
           Claims claim = GetClaimByID(id);
            if (claim == null)
            {
                return false;
            }
            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(claim);
            if(initialCount > _listOfClaims.Count)
            {
                return true;
            }
            return false;
        }
        //Helper Method
        public Claims GetClaimByID(int id)
        {
            foreach(Claims claim in _listOfClaims)
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
