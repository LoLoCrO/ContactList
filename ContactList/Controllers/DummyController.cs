using ContactList.Entities;
using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactList.Controllers
{
    public class DummyController : Controller
    {
        private IContactListRepository _contactListRepository;

        public DummyController(IContactListRepository contactListRepository)
        {
            _contactListRepository = contactListRepository;
        }

        [HttpGet]
        [Route("api/testbase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/test2")]
        public IActionResult Test2()
        {
            return BadRequest();
        }

        [HttpGet]
        [Route("api/testdata")]
        public JsonResult TestData()
        {
            return new JsonResult(new List<object>()
            {
                new { id = 1, Name = "NYC"},
                new { id = 2, Name = "LA"}
            });
        }

        [HttpGet]
        [Route("api/getusersbytag/{tag}")]
        public IActionResult GetUsersByTag(string tag)
        {
            var listOfContacts = _contactListRepository.GetUsersByTag(tag);
            var result = new List<ContactDto>();
            var tagDto = new TagDto();
            var numberDto = new NumberDto();
            var emailDto = new EmailDto();
            //Emails = emailDto.ListToDtos(contact.Emails),
            //Numbers = numberDto.ListToDtos(contact.Numbers),
            //Tags = tagDto.ListToDtos(contact.Tags)
            foreach (var contact in listOfContacts)
            {
                result.Add(
                    new ContactDto
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Address = contact.Address,
                        Bookmarked = contact.Bookmarked,
                        Emails = emailDto.ListToDtos(contact.Emails),
                        Numbers = numberDto.ListToDtos(contact.Numbers),
                        Tags = tagDto.ListToDtos(contact.Tags)
                    }
                    );
            }

            return Ok(result);
        }
    }
}
