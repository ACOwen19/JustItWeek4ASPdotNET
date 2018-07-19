using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPartyTutorial.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your e-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Please enter a valid e-mail address")]
        // Regular expression validates the text entry, in this case it is any character folowed by an @ followed by any text followed by a dot followed by any text
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please say whether you are attending or not")]
        public bool? WillAttend { get; set; }
        // bool? means the variable can be null as well as true or false, ie: havent replied 

    }
}