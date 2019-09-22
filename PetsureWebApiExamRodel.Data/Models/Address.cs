using System.ComponentModel.DataAnnotations;

namespace PetsureWebApiExamRodel.Data.Models
{
    public  class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}
