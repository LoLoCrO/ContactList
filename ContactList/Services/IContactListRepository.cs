using ContactList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public interface IContactListRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int ContactId);
        IEnumerable<Email> GetEmailsForContact(int contactId);
        Email GetEmailForContact(int contactId, int emailId);
        IEnumerable<Number> GetNumbersForContact(int contactId);
        Number GetNumberForContact(int contactId, int numberId);
        IEnumerable<Tag> GetTagsForContact(int contactId);
        Tag GetTagForContact(int contactId, int tagId);
        IEnumerable<Contact> GetUsersByTag(string tag);
    }
}
