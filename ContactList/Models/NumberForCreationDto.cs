using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
  public class NumberForCreationDto
  {
    [Required]
    [MaxLength(13)]
    public int ContactNumber { get; set; }
    public int ContactId { get; set; }
  }
}
