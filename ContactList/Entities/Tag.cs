using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entities
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ContactTag { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}
