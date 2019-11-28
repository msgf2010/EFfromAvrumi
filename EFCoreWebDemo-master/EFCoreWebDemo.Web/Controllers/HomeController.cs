using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebDemo.Data;
using Microsoft.AspNetCore.Mvc;
using EFCoreWebDemo.Web.Models;
using Microsoft.Extensions.Configuration;

namespace EFCoreWebDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            var repo = new PeopleRepository(_connectionString);
            return View(repo.GetPeople());
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Add(person);
            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            var repo = new PeopleRepository(_connectionString);
            var person = repo.GetById(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Update(person);
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Delete(id);
            return Redirect("/");

        }
    }
}
