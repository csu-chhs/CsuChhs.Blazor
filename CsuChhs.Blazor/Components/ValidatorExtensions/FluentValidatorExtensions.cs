namespace CsuChhs.Blazor.Components.ValidatorExtensions;
using System.Text.RegularExpressions;
using FluentValidation;

public static class FluentValidatorExtensions
{
    private const string PhoneNumberPattern =
        @"^\s*(?:\+?1[-.\s]?)?(?:\(?\d{3}\)?[-.\s]?)\d{3}[-.\s]?\d{4}\s*$";

    public static IRuleBuilderOptions<T, string?> PhoneNumberOrEmpty<T>(
        this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder
            .Must(phone =>
                string.IsNullOrWhiteSpace(phone) ||
                Regex.IsMatch(phone, PhoneNumberPattern))
            .WithMessage("Please enter a valid phone number.");
    }
}