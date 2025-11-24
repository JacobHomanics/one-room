using UnityEngine;

public class IsHostileUI : MonoBehaviour
{
    public TargetManager targetManager;
    public GameObject go;

    void Update()
    {
        go.SetActive(!targetManager.isHostile);
    }
}
