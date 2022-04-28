using Microsoft.AspNetCore.Mvc;
using Customers.Data.Models;
using Customers.Data.Repositories;
using System;
using System.Linq;

namespace Customers.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customerList = this.customerRepository.FindAll().ToList();
            return View(customerList);
        }

        public IActionResult Details(Guid id)
        {
            var customer = this.customerRepository.FindByPrimaryKey(id);
            ViewData["Customer"] = customer;
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var customer = this.customerRepository.Delete(id);
            
            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            ViewData["Action"] = "New";
            return View("Form", new Customer());
        }

        public IActionResult Edit(Guid id)
        {
            ViewData["Action"] = "Edit";
            var customer = this.customerRepository.FindByPrimaryKey(id);
            return View("Form", customer);
        }

        public IActionResult Save(string action, Customer customer)
        {
            if (ModelState.IsValid)
            {
                if(action.ToLower().Equals("new"))
                {
                    customerRepository.Insert(customer);
                } else if (action.ToLower().Equals("edit"))
                {
                    customerRepository.Update(customer);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", customer);
            }
        }

    }
}
