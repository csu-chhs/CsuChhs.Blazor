using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace CsuChhs.Blazor.Components.Forms
{

    // Code for this found here: https://www.meziantou.net/creating-a-inputselect-component-for-enumerations-in-blazor.htm

    // Inherit from InputBase so the hard work is already implemented 😊
    // Note that adding a constraint on TEnum (where T : Enum) doesn't work when used in the view, Razor raises an error at build time. Also, this would prevent using nullable types...
    public sealed class InputSelectEnum<TEnum> : InputBase<TEnum>
    {
        // Generate html when the component is rendered.
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString, null));

            // Add default null option
            builder.OpenElement(5, "option");
            builder.AddAttribute(6, "value", "null");
            builder.AddContent(7, "Choose an option");
            builder.CloseElement();

            // Add an option element per enum value
            var enumType = GetEnumType();
            int index = 0;

            foreach (KeyValuePair<string, string> entry in _GetOrderedDict())
            {
                builder.OpenElement(5, "option");
                builder.AddAttribute(6, "value", entry.Key.ToString());
                builder.AddContent(7, entry.Value);
                builder.CloseElement();

                index++;
            }

            builder.CloseElement(); // close the select element
        }

        protected override bool TryParseValueFromString(string value, out TEnum result, out string validationErrorMessage)
        {
            // Let's Blazor convert the value for us 😊
            if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TEnum parsedValue))
            {
                result = parsedValue;
                validationErrorMessage = null;
                return true;
            }

            // Map null/empty value to null if the bound object is nullable
            if (string.IsNullOrEmpty(value) || value == "null")
            {
                var nullableType = Nullable.GetUnderlyingType(typeof(TEnum));
                if (nullableType != null)
                {
                    result = default;
                    validationErrorMessage = null;
                    return true;
                }
            }

            // The value is invalid => set the error message
            result = default;
            validationErrorMessage = $"Please select a valid option for {FieldIdentifier.FieldName}.";
            return false;
        }

        // Get the display text for an enum value:
        // - Use the DisplayAttribute if set on the enum member, so this support localization
        // - Fallback on Humanizer to decamelize the enum member name
        private string GetDisplayName(TEnum value)
        {
            // Read the Display attribute name
            var member = value.GetType().GetMember(value.ToString())[0];
            var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null)
            {
                return displayAttribute.GetName();
            }

            // Require the NuGet package Humanizer.Core
            // <PackageReference Include = "Humanizer.Core" Version = "2.8.26" />
            return value.ToString().Humanize();
        }

        // Get the actual enum type. It unwrap Nullable<T> if needed
        // MyEnum  => MyEnum
        // MyEnum? => MyEnum
        private Type GetEnumType()
        {
            var nullableType = Nullable.GetUnderlyingType(typeof(TEnum));
            if (nullableType != null)
                return nullableType;

            return typeof(TEnum);
        }

        /// <summary>
        /// Converts the Enum into an ordered dictionary
        /// so that the elements in the input select
        /// are ordered alphabetically.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> _GetOrderedDict()
        {
            var enumType = GetEnumType();
            Dictionary<string, string> enumDict = new Dictionary<string, string>();

            foreach (TEnum value in Enum.GetValues(enumType))
            {
                enumDict.Add(value.ToString(), GetDisplayName(value));
            }

            return enumDict.OrderBy(s => s.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
