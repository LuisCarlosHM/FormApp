using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    public class FormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

    }
}


