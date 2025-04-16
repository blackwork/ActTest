namespace Extension.Tool1;

public static class Constants
{
    public const string TestVar1 = "MY_VAR_1";
    public static IDictionary<string, string> DefaultEnv => new Dictionary<string, string>()
    {
        { TestVar1, null }
    }; 
}