using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        // The "\s" allows spaces, use double "\\" to avoid using the escape character
        [Required(ErrorMessage = "Please enter a description.")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$", ErrorMessage ="Description may not contain any special characters.")]
        public string Description { get; set; }

        [Today]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue => 
            StatusId == "open" && DueDate < DateTime.Today;
    }
}
