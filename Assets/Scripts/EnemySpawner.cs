using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] go;

    [ContextMenu("SPawns")]
    public void Spawn()
    {
        var rn = Random.Range(0, go.Length);
        var newGo = Instantiate(go[rn], transform.position, Quaternion.identity);
        // newGo.transform.position = transform.position;
    }

    [SerializeField] private float gizmoRadius;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}
