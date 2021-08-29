using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using WebPhim.App_Start;
using WebPhim.Dtos;
using WebPhim.Models;

namespace WebPhim.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private MapperConfiguration config;
        private IMapper iMapper;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper(); //Khởi tạo mapper
        }
        // GET /api/Customers
        public IHttpActionResult getCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
                var customersDto = customersQuery
                .ToList().Select(iMapper.Map<Customer,CustomerDto>);
            return Ok(customersDto);
        }
        // GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); 
            }
            return Ok(iMapper.Map<Customer, CustomerDto>(customer));
        }
        // POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var customer = iMapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri (Request.RequestUri +"/"+customer.Id),customerDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer (int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            iMapper.Map(customerDto, customerInDB);            
            _context.SaveChanges();
        }
        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);                            
            }
            _context.Customers.Remove(CustomerInDB);
            _context.SaveChanges();
        }
    }
}
