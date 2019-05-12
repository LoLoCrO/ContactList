using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
  public class ContactForCreationDto
  {
    [Required(ErrorMessage = "You should provide a first name.")]
    [MaxLength(20)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "You should provide a last name.")]
    [MaxLength(20)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    public bool? Bookmarked { get; set; }
  }
}
