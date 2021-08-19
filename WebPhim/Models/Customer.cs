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
        [Required( ErrorMessage = "Vui lòng nhập tên khách hàng.")]
        [StringLength(255)]        
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }        
        public MembershipType MembershipType { get; set; } 
        [Required(ErrorMessage = "Vui lòng chọn loại thành viên.")]
        public byte MembershipTypeId { get; set; }     
        [MinYearsIfAMember]
        public DateTime? SinhNhat { get; set; }

    }
}