using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Entities;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.Include(c => c.Numbers).Include(c => c.Tags).Include(c => c.Emails)
                .OrderBy(c => c.FirstName).ToList();
        }

        public Email GetEmailForContact(int contactId, int emailId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Email> GetEmailsForContact(int contactId)
        {
            return _context.Emails.Where(c => c.ContactId == contactId).ToList();
        }

        public Number GetNumberForContact(int contactId, int numberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Number> GetNumbersForContact(int contactId)
        {
            return _context.Numbers.Where(c => c.ContactId == contactId).ToList();
        }

        public IEnumerable<Contact> GetUsersByTag(string tag)
        {
            List<Tag> tagList = _context.Tags.Where(t => t.ContactTag == tag).ToList();

            return _context.Contacts.Include(c => c.Tags).Include(c => c.Emails).Include(c => c.Numbers)
                .Where(c => ContactExistsInTags(tagList, c.Id)).ToList();
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
            throw new NotImplementedException();
        }
    }
}
