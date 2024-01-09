namespace Stll.Library.Public.Results;

public class ApiBridgeResponse<TResult>
{
    public uint Code { get; set; }
    public TResult Value { get; set; }
    public bool Success { get; set; }
    public string Error { get; set; }
}