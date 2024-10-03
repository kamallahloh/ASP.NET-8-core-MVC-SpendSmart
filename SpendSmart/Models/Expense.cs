using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; } // here there is a default value 0 and will not give null so no need for ?

        [Required] // data anotation 
        // string with ? now you can have a null value inside it but with Require you need value 
        public string? Description { get; set; }
    }
}
