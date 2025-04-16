namespace mybuildtool.CiCd;

public interface ICiCdSupport
{
    string GetEnv(string key);
    void SetEnv(string key, string value);
}