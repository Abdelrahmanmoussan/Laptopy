using Laptopy.DTOs.Request;
using Laptopy.Models;
using Laptopy.Repository;
using Laptopy.Repository.IRepository;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        [HttpGet ("")]
        public IActionResult GetAll()
        {
            var contacts = _contactUsRepository.Get();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            var contact = _contactUsRepository.Get(e=>e.Id == id);

            if (contact != null) 
            return Ok(contact);

            return NotFound();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ContactUsRequest contactUs)
        {
            var contactDb = _contactUsRepository.Create(new ContactUs()
            {
                Name = contactUs.Name,
                Email = contactUs.Email,
                Message = contactUs.Message

            });
            return CreatedAtAction(nameof(GetOne), new { id = contactDb.Id }, contactUs);
        }



    }
}
