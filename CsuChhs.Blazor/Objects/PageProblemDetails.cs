namespace CsuChhs.Blazor.Objects;

public class PageProblemDetails
{
    public PageProblemDetails()
    {
        IsError = false;
        Message = string.Empty;
    }

    public PageProblemDetails(string message)
    {
        IsError = true;
        Message = message;
    }
    
    public bool IsError { get; init; }
    public string Message { get; init; }
}