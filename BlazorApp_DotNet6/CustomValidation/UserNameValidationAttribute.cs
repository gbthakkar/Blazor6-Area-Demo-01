using System.ComponentModel.DataAnnotations;

namespace BlazorApp_DotNet6.CustomValidation;

public class UserNameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string fieldValue = value.ToString() ?? "";
        string displayName = validationContext.MemberName ?? validationContext.DisplayName;
        if (string.IsNullOrEmpty(displayName))
        {
            displayName = "User/Login Name";
        }

        bool isError = false;
        foreach (char c in fieldValue)
        {
            if (!char.IsLetterOrDigit(c))
            {
                isError = true;
                break;
            }
        }
        var result = ValidationResult.Success;
        if (isError)
        {
            var errMsg = ErrorMessage;
            if (string.IsNullOrWhiteSpace(errMsg))
            {
                errMsg = $"{displayName} can not contain space or special character";
            }

            result = new ValidationResult(errMsg, new[] { displayName });
        }

        return result;
    }
}
