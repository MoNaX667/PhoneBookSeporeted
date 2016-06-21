namespace WebModule.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model of contact
    /// </summary>
    public class ContactView
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name prop
        /// </summary>
        [Required(ErrorMessage = "Name cannot be empty")]
        [Display(Name = "Person Name")]
        [RegularExpression("[a-zA-Z]+\\s[a-zA-Z]+", ErrorMessage = 
            "Name should be next format \"FirstName SecondName\"")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Phone number prop
        /// </summary>
        [Required(ErrorMessage = "Phone Number cannot be empty")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        [RegularExpression("\\d-\\d\\d\\d-\\d\\d\\d-\\d\\d\\d\\d", ErrorMessage =
            "Name should be next format x-xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }
    }
}