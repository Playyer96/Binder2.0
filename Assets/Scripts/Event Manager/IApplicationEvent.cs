public interface IApplicationEvent
{
    void Invoke();
    void InvokeInt(int value);
    void InvokeString(string value);
    void InvokeDoubleString(string value1, string value2);
    void InvokeDoubleInt(int value1, int value2);
}
