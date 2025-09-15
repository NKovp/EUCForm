using EUCFormApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace EUCFormApp.Models
{
    public class ApplicantViewModel
    {
        [Required(ErrorMessage = "FullName.Required")]
        [Display(Name = "FullName.DisplayName")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "BirthNumber.DisplayName")]
        [RegularExpression(
            @"^\d{2}(0[1-9]|1[0-2]|5[1-9]|6[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])\/?\d{3,4}$", 
            ErrorMessage = "BirthNumber.Invalid")]
        public string? BirthNumber { get; set; }

        public bool NoBirthNumber { get; set; }

        [Required(ErrorMessage = "DateOfBirth.Required")]
        [Display(Name = "DateOfBirth.DisplayName")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender.Required")]
        [Display(Name = "Gender.DisplayName")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email.Required")]
        [EmailAddress(ErrorMessage = "Email.Invalid")]
        [Display(Name = "Email.DisplayName")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nationality.Required")]
        [Display(Name = "Nationality.DisplayName")]
        public string Nationality { get; set; } = string.Empty;

        [CheckBoxRequired(ErrorMessage = "GdprConsent.Required")]
        [Display(Name = "GdprConsent.DisplayName")]
        public bool GdprConsent { get; set; }
    }
}