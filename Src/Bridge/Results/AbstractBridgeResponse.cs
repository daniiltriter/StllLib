namespace Stll.Bridge.Results;

public abstract class AbstractBridgeResponse
{
    public uint Code { get; set; }
    
    public bool Success { get; set; }
    public string Error { get; set; }
}