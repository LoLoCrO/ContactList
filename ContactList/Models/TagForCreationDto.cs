using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
  public class TagForCreationDto
  {
    [Required]
    [MaxLength(30)]
    public string ContactTag { get; set; }
    public int ContactId { get; set; }
  }
}
