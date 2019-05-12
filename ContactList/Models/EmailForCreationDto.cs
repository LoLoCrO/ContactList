using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Models
{
  public class EmailForCreationDto
  {
    [Required]
    [MaxLength(50)]
    public string ContactEmail { get; set; }
    public int ContactId { get; set; }
  }
}
