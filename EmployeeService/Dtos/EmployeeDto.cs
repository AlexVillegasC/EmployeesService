using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Dtos
{
    public class AddressDto
    {     
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public object District { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class EmployeeDto
    {        
        public int Id { get; set; }

        public AddressDto address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
