using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPhim.Models
{
    public class MinYearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.khách )
            {
                return ValidationResult.Success;
            }
            if (customer.SinhNhat == null)
            {
                return new ValidationResult("Mời bạn nhập ngày sinh.");
            }
            var age = DateTime.Today.Year - customer.SinhNhat.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success : new ValidationResult(" Bạn cần trên 18 tuổi để đăng kí thành viên."); 
        }       
    }
}