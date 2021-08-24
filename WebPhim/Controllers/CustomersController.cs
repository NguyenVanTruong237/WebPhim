using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPhim.Models;
using System.Web.Mvc;
using WebPhim.ViewModel;

namespace WebPhim.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }  
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var modelView = new CustomerFormViewModel
            {
                customer = new Customer(),
                membershipTypes = membershipType            
            };
            return View("customerForm", modelView);
        }
        public ActionResult Edit(int id) 
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel
            {
                customer = customers,
                membershipTypes = _context.MembershipTypes.ToList()
           };
            return View("CustomerForm",viewModel);
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) //dữ liệu của object nhập vào không có giá trị
            {
                var viewModel = new CustomerFormViewModel
                {
                    customer = new Customer(),
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id ==0 )
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.SinhNhat = customer.SinhNhat;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ViewResult Index()
        {           
            return View();
        }
        // details
        //public ActionResult Details(int id)
        //{
        //    var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}
        // GET: Customers
    }
}