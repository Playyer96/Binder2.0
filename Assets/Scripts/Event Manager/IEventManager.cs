public interface IEventManager {
    T GetEvent<T>();
    void Invoke<T>();
    void InvokeInt<T>(int value);
    void InvokeString<T>(string value);
    void InvokeDoubleString<T>(string value1, string value2);
    void InvokeFloat<T>(float value);
    void InvokeBool<T>(bool value);
    void InvokeDoubleBool<T> (bool value1,bool value2);
    void InvokeObject<T> (object value);
}