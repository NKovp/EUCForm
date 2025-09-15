using EUCFormApp.Models;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace EUCFormApp.Validation
{
    public class CheckBoxRequired : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Checkbox je zaškrtnutý
            if (value is bool b && b)
                return ValidationResult.Success;

            // Vytahneme si localizer pro daný typ
            var localizerType = validationContext.ObjectType;
            var localizer = (IStringLocalizer?)validationContext
                .GetService(typeof(IStringLocalizer<>).MakeGenericType(localizerType));

            // Klíč si vezmem z ErrorMessage nebo defaultní
            var key = ErrorMessage ?? "GdprConsent.Required";
            var localized = localizer?[key] ?? key;

            return new ValidationResult(localized);
        }
    }
}
