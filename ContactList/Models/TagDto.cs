using ContactList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class TagDto
    {
        public int Id { get; set; }
        public string ContactTag { get; set; }
        public int ContactId { get; set; }
        public List<TagDto> ListToDtos(ICollection<Tag> tags)
        {
            var Dtos = new List<TagDto>();

            foreach(var tag in tags)
            {
                Dtos.Add(new TagDto {
                    Id = tag.Id,
                    ContactTag = tag.ContactTag,
                    ContactId = tag.ContactId
                });
            }
            
            return Dtos;
        }
    }
}
