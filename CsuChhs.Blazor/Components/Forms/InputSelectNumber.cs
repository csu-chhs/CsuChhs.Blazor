using Microsoft.AspNetCore.Components.Forms;

namespace CsuChhs.Blazor.Components.Forms
{
    public class InputSelectNumber<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(int?))
            {
                if (int.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = (T)(object)null;
                    validationErrorMessage = null;
                    return true;
                }
            }
            else if (typeof(T) == typeof(double))
            {
                if (double.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(double?))
            {
                if (double.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = (T)(object)null;
                    validationErrorMessage = null;
                    return true;
                }
            }
            else if (typeof(T) == typeof(long))
            {
                if (long.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(long?))
            {
                if (long.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = (T)(object)null;
                    validationErrorMessage = null;
                    return true;
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (float.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(float?))
            {
                if (float.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = (T)(object)null;
                    validationErrorMessage = null;
                    return true;
                }
            }
            else if (typeof(T) == typeof(decimal))
            {
                if (decimal.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else if (typeof(T) == typeof(decimal?))
            {
                if (decimal.TryParse(value, out var resultNum))
                {
                    result = (T)(object)resultNum;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = (T)(object)null;
                    validationErrorMessage = null;
                    return true;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
