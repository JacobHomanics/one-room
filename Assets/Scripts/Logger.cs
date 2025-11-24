using UnityEngine;

public class Logger : MonoBehaviour
{
    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void Log(Collider col)
    {
        Debug.Log(col.name);
    }

}
