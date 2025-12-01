using JacobHomanics.Timer;
using UnityEngine;

public class RandomTimer : MonoBehaviour
{
    public EnemySpawner[] spawners;
    public Timer timer;
    public float minDuration;
    public float maxDuration;

    // void Awake()
    // {
    //     timer.Duration = Random.Range(minDuration, maxDuration);
    //     timer.Restart();
    // }

    public void Spawn()
    {
        var rn = Random.Range(0, spawners.Length);
        spawners[rn].Spawn();

        timer.Duration = Random.Range(minDuration, maxDuration);
        timer.Restart();
    }
}
