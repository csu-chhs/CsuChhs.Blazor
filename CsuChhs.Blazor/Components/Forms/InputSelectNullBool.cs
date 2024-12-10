using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace CsuChhs.Blazor.Components.Forms;

public class InputSelectNullBool : InputBase<bool?>
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "select");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "value", CurrentValueAsString);
        builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString ?? throw new InvalidOperationException(), null));

        builder.OpenElement(5, "option");
        builder.AddAttribute(6, "value", "");
        builder.AddContent(7, "Both");
        builder.CloseElement();
        
        // Yes
        builder.OpenElement(5, "option");
        builder.AddAttribute(6, "value", "True");
        builder.AddContent(7, "Yes");
        builder.CloseComponent();
        
        // No
        builder.OpenElement(5, "option");
        builder.AddAttribute(6, "value", "False");
        builder.AddContent(7, "No");
        builder.CloseElement();
        builder.CloseElement();
    }
    
    protected override bool TryParseValueFromString(string? value, 
        out bool? result, 
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        validationErrorMessage = null;
        if (value == "True")
        {
            result = true;
            return true;
        }

        if (value == "False")
        {
            result = false;
            return true;
        }

        if (string.IsNullOrEmpty(value))
        {
            result = null;
            return true;
        }
        
        // The value is invalid => set the error message
        result = default;
        validationErrorMessage = $"Please select a valid option for {FieldIdentifier.FieldName}.";
        return false;
    }
}