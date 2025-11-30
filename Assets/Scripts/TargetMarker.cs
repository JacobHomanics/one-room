using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    public TargetManager targetManager;

    public GameObject marker;

    void Update()
    {
        marker.SetActive(targetManager.target);

        if (targetManager.target)
            marker.transform.position = new(targetManager.target.position.x, 0, targetManager.target.position.z);
    }
}
