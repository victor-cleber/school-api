using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using SchoolApi.Models;
using SchoolApi.Services;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        
        private Guid id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

        public SchoolController(SchoolDbContext schoolDbContext)
        {
            _context = schoolDbContext;

            dynamic school =  _context.Schools.Find(id);
            
            if (!SchoolExists(school.Id)){
                _context.Schools.Add(
                    new School{
                        Id = id,
                        CompanyName = "School of the future",
                        TradingName = "School of the future",
                        WebSite = "www.schoolofthefuture.com",
                        Phone = "+ 234 52 656 12337",
                        Address = "4340 Thompson Av, El Pargo, CA 99313, United States"
                    }
                );
                _context.SaveChangesAsync();
            }            
        }

        private bool SchoolExists(Guid id){
            return _context.Schools.Any(s => s.Id == id);
        }

        [HttpGet]
        [Route("/school")]
        public async Task<ActionResult<School>> Get()
        {
            var school = await _context.Schools.FindAsync(id);

            return StatusCode(200, new{
                Id = school.Id,
                CompanyName = school.CompanyName,
                TradingName = school.TradingName,
                WebSite= school.WebSite,
                Phone  =school.Phone,
                Addres = school.Address
            });
        }
    }
}