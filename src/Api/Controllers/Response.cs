namespace Api.Controllers;

public record Void;
public record Response<TData>
{
    public Response(TData? data)
    {
        Data      = data;
        HasErrors = false;
    }

    public Response(string? message, TData? data)
    {
        Message   = message;
        Data      = data;
        HasErrors = false;
    }

    public Response(string? message, bool hasErrors)
    {
        Message   = message;
        HasErrors = hasErrors;
    }

    public Response(string? message)
    {
        Message   = message;
        HasErrors = true;
    }

    public string? Message   { get; set; }
    public TData?  Data      { get; set; }
    public bool    HasErrors { get; set; }
}
