using ContactList.Entities;
using ContactList.Models;
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
    void CreateContact(Contact contact);
    void DeleteContact(Contact contact);
    void UpdateContact(Contact contact);
    IEnumerable<Email> GetEmailsForContact(int contactId);
    Email GetEmailForContact(int contactId, int emailId);
    void CreateEmail(Email email);
    void DeleteEmail(Email email);
    void UpdateEmail(Email email);
    IEnumerable<Number> GetNumbersForContact(int contactId);
    Number GetNumberForContact(int contactId, int numberId);
    void CreateNumber(Number number);
    void DeleteNumber(Number number);
    void UpdateNumber(Number number);
    IEnumerable<Tag> GetTagsForContact(int contactId);
    Tag GetTagForContact(int contactId, int tagId);
    void CreateTag(Tag tag);
    void DeleteTag(Tag tag);
    void UpdateTag(Tag tag);
    IEnumerable<Contact> GetContactsByFirstName(string firstName);
    IEnumerable<Contact> GetContactsByLastName(string lastName);
    IEnumerable<Contact> GetContactsByTag(string tag);
    IEnumerable<Contact> GetBookmarkedContacts();
    bool Save();
  }
}
