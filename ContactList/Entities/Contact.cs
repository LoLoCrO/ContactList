using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public bool Bookmarked { get; set; }

        public ICollection<Email> Emails { get; set; } = new List<Email>();
        public ICollection<Number> Numbers { get; set; } = new List<Number>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
