using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject go;

    public void Spawn()
    {
        var newGo = Instantiate(go);
        newGo.transform.position = transform.position;
    }

    [SerializeField] private float gizmoRadius;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}
