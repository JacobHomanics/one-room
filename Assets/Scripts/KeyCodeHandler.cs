using UnityEngine;
using UnityEngine.Events;

public class KeyCodeHandler : MonoBehaviour
{
    public KeyCode keyCode;
    public UnityEvent onUp;

    void Update()
    {
        if (Input.GetKeyUp(keyCode))
        {
            onUp?.Invoke();
        }
    }
}
