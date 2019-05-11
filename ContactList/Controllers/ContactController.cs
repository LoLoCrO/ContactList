using AutoMapper;
using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.Controllers
{
    public class ContactController : Controller
    {
        private IContactListRepository _contactListRepository;

        public ContactController(IContactListRepository contactListRepository)
        {
            _contactListRepository = contactListRepository;
        }

        [HttpGet]
        [Route("api/getallcontacts")]
        public IActionResult GetAllContacts()
        {
            var listOfContacts = _contactListRepository.GetContacts();

            if (listOfContacts == null)
            {
                return NoContent();
            }

            var allContacts = Mapper.Map<IEnumerable<ContactDto>>(listOfContacts);
            return Ok(allContacts);
        }

        [HttpGet]
        [Route("api/getusersbytag/{tag}")]
        public IActionResult GetUsersByTag(string tag)
        {
            var listOfContacts = _contactListRepository.GetUsersByTag(tag);

            if(listOfContacts == null)
            {
                return NoContent();
            }

            var result = new List<ContactDto>();
            var tagDto = new TagDto();
            var numberDto = new NumberDto();
            var emailDto = new EmailDto();

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
