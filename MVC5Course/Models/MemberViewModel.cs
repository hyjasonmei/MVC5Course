using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class MemberViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage="Birsthday msut be date")]
        public DateTime Birthday { get; set; }
    }
}