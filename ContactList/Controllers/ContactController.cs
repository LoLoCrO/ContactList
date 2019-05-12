using AutoMapper;
using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.Controllers
{
  [Route("api/[Controller]")]
  public class ContactController : Controller
  {
    private IContactListRepository _contactListRepository;

    public ContactController(IContactListRepository contactListRepository)
    {
      _contactListRepository = contactListRepository;
    }

    [HttpPost("/api/createcontact")]
    public IActionResult CreateContact([FromBody] ContactDto contactForCreation)
    {

      // return Ok(contactForCreation);
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var finalContact = Mapper.Map<Entities.Contact>(contactForCreation);
     // return Ok(finalContact);
      _contactListRepository.CreateContact(finalContact);

      if (!_contactListRepository.Save())
      {
        return StatusCode(500, "A problem happened while handling your request.");
      }

     var createdContactToReturn = Mapper.Map<Entities.Contact>(finalContact);

      return Ok(createdContactToReturn);
    }

    [HttpGet]
    [Route("/api/getallcontacts")]
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
    [Route("/api/getcontact/{contactId}")]
    public IActionResult GetContact(int contactId)
    {
      var contact = _contactListRepository.GetContact(contactId);

      if (contact == null)
      {
        return NoContent();
      }

      var finalContact = Mapper.Map<IEnumerable<ContactDto>>(contact);
      return Ok(finalContact);
    }

    [HttpPut("/api/updatecontact/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contact)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      Mapper.Map<Entities.Contact>(contact);

      if (!_contactListRepository.Save())
      {
        return StatusCode(500, "A problem happened while handling your request.");
      }

      return NoContent();
    }

    [HttpGet]
    [Route("api/getcontactsbytag/{tag}")]
    public IActionResult GetContactsByTag(string tag)
    {
      var listOfContacts = _contactListRepository.GetContactsByTag(tag);

      if (listOfContacts == null)
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

    [HttpGet]
    [Route("api/getcontactsbyfirst/{firstName}")]
    public IActionResult GetContactsByFirstName(string firstName)
    {
      var listOfContacts = _contactListRepository.GetContactsByFirstName(firstName);

      if (listOfContacts == null)
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

    [HttpGet]
    [Route("api/getcontactsbylast/{lastName}")]
    public IActionResult GetContactsByLastName(string lastName)
    {
      var listOfContacts = _contactListRepository.GetContactsByLastName(lastName);

      if (listOfContacts == null)
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

    [HttpGet]
    [Route("api/getbookmarked")]
    public IActionResult GetBookmarkedContacts()
    {
      var listOfContacts = _contactListRepository.GetBookmarkedContacts();

    if (listOfContacts == null)
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

