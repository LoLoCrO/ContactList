using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entities
{
    public class Number
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(13)]
        public int ContactNumber { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}
