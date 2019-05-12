using System.Collections.Generic;

namespace ContactList.Models
{
  public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    public bool? Bookmarked { get; set; }

        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        public ICollection<NumberDto> Numbers { get; set; } = new List<NumberDto>();
        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();

    }
}
