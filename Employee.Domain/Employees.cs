using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Domain
{
    public class Employees
    {
        public Employees()
        {
            // Initialize values.
            this.Address = new Address();
        }
        //Unique fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //Others
        public Address Address { get; set; }
        
        public int Age { get; set; }
        public State RecordState { get; set; }


    }
    public enum State
    {
        Deleted,
        Active        
    }
}
