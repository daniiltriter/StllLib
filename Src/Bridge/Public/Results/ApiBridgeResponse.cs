namespace Stll.Bridge.Public.Results;

public class ApiBridgeResponse
{
    public uint Code { get; set; }
    public string Content { get; set; }
    public bool Success { get; set; }
    public string Error { get; set; }
}