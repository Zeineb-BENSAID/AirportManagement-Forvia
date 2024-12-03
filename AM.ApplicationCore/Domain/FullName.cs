using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "min lenght is 3 !"), MaxLength(25, ErrorMessage = "max lenght must be 25!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
