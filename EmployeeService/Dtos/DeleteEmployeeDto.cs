using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Dtos
{
    public class DeleteEmployeeDto
    {                      
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
     
    }
}
