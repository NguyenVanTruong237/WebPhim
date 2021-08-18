using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPhim.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]        
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }        
        public MembershipType MembershipType { get; set; }          
        public byte MembershipTypeId { get; set; }       
        public DateTime? SinhNhat { get; set; }

    }
}