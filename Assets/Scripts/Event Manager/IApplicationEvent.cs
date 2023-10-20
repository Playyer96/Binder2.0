public interface IApplicationEvent
{
    void Invoke();
    void InvokeInt(int value);
    void InvokeString(string value);
    void InvokeDoubleString(string value1, string value2);
    void InvokeDoubleInt(int value1, int value2);
    void InvokeFloat(float value);
    void InvokeDoubleFloat(float value1, float value2);
    void InvokeTripleFloat(float value1, float value2, float value3);
    void InvokeBool(bool value);
    void InvokeDoubleBool(bool value1, bool value2);
    void InvokeBoolString(bool value1, string value2);
    void InvokeObject(object value);
    void InvokeGameObject(UnityEngine.GameObject value);
    void InvokeTwoGameObject(UnityEngine.GameObject value1, UnityEngine.GameObject value2);
    void InvokeDouble(double value);
}
