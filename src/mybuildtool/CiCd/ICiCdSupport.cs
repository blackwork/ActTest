namespace mybuildtool.CiCd;

public interface ICiCdSupport
{
    string EnvironmentType { get; }
    string GetEnv(string key);
    void SetEnv(string key, string value);
}