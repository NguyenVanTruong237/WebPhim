using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPhim.Models;

namespace WebPhim.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}