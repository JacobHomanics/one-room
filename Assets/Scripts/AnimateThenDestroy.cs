using UnityEngine;
using UnityEngine.Events;

public class AnimateThenDestroy : MonoBehaviour
{
    public GameObject go;

    public void Do()
    {
        Destroy(go);
    }
}