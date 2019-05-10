using ContactList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class NumberDto
    {
        public int Id { get; set; }
        public int ContactNumber { get; set; }
        public int ContactId { get; set; }

        public List<NumberDto> ListToDtos(ICollection<Number> numbers)
        {
            var Dtos = new List<NumberDto>();

            foreach (var number in numbers)
            {
                Dtos.Add(new NumberDto
                {
                    Id = number.Id,
                    ContactNumber = number.ContactNumber,
                    ContactId = number.ContactId
                });
            }

            return Dtos;
        }
    }
}
