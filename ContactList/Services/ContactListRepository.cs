using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ContactList.Entities;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Services
{
  public class ContactListRepository : IContactListRepository
    {
        private ContactContext _context;
        public ContactListRepository(ContactContext context)
        {
            _context = context;
        }
        public Contact GetContact(int ContactId)
        {
            return _context.Contacts.Include(c => c.Tags).Include(c => c.Numbers).Include(c => c.Emails)
              .Where(c => c.Id == ContactId).FirstOrDefault();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.Include(c => c.Numbers).Include(c => c.Tags).Include(c => c.Emails)
                .OrderBy(c => c.FirstName).ToList();
        }

        public void CreateContact(Contact contact) {
            _context.Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
        }

        public IEnumerable<Contact> GetContactsByTag(string tag)
        {
          List<Tag> tagList = _context.Tags.Where(t => t.ContactTag == tag).ToList();

          return _context.Contacts.Include(c => c.Tags).Include(c => c.Emails).Include(c => c.Numbers)
              .Where(c => ContactExistsInTags(tagList, c.Id)).ToList();
        }
    
        public IEnumerable<Contact> GetContactsByFirstName(string firstName)
        {
          return _context.Contacts.Where(c => c.FirstName == firstName).ToList();
        }

        public IEnumerable<Contact> GetContactsByLastName(string lastName)
        {
          return _context.Contacts.Where(c => c.LastName == lastName).ToList();
        }

        public Email GetEmailForContact(int contactId, int emailId)
        {
           return _context.Emails.Where(e => e.Id == contactId && e.Id == emailId).FirstOrDefault();
        }

        public void CreateEmail(Email email)
        {
            _context.Emails.Add(email);
        }

        public void DeleteEmail(Email email)
        {
            _context.Emails.Remove(email);
        }

        public void UpdateEmail(Email email)
        {
            _context.Emails.Update(email);
        }

        public IEnumerable<Email> GetEmailsForContact(int contactId)
        {
            return _context.Emails.Where(c => c.ContactId == contactId).ToList();
        }

        public Number GetNumberForContact(int contactId, int numberId)
        {
             return _context.Numbers.Where(n => n.ContactId == contactId && n.Id == numberId).FirstOrDefault();
        }

        public IEnumerable<Number> GetNumbersForContact(int contactId)
        {
            return _context.Numbers.Where(c => c.ContactId == contactId).ToList();
        }

        public void CreateNumber(Number number)
        {
            _context.Numbers.Add(number);
        }

        public void DeleteNumber(Number number)
        {
            _context.Numbers.Remove(number);
        }

        public void UpdateNumber(Number number)
        {
            _context.Numbers.Update(number);
        }

        public IEnumerable<Contact> GetBookmarkedContacts()
        {
            return _context.Contacts.Where(c => c.Bookmarked == true).ToList();
        }

        public void UpdateBookmark(Contact contact)
        {
            _context.Contacts.Update(contact);
        }

        public IEnumerable<Tag> GetTagsForContact(int contactId)
        {
           return _context.Tags.Where(t => t.ContactId == contactId).ToList();
        }

        private bool ContactExistsInTags(List<Tag> tagList, int contactId)
        {
            for(int i = 0; i < tagList.Count; i++)
            {
                if (tagList[i].ContactId == contactId)
                {
                    return true;
                }
            }
            return false;
        }

        public Tag GetTagForContact(int contactId, int tagId)
        {
            return _context.Tags.Where(t => t.ContactId == contactId  && t.Id == tagId).FirstOrDefault();
        }

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public void UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public bool Save()
        {
          return (_context.SaveChanges() >= 0);
        }
    }
}
