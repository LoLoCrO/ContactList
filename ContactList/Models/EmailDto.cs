using ContactList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class EmailDto
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public int ContactId { get; set; }

        public List<EmailDto> ListToDtos(ICollection<Email> emails)
        {
            var Dtos = new List<EmailDto>();

            foreach (var email in emails)
            {
                Dtos.Add(new EmailDto
                {
                    Id = email.Id,
                    ContactEmail = email.ContactEmail,
                    ContactId = email.ContactId
                });
            }

            return Dtos;
        }
    }
}
