using UnityEngine;
using JacobHomanics.Timer;

public class TimerEnabler : MonoBehaviour
{
    public Timer timer;
    [System.Serializable]
    public struct Yes
    {
        public GameObject go;
        public float time;
    }

    public Yes[] yes;
    void Update()
    {
        foreach (var y in yes)
        {
            if (timer.ElapsedTime > y.time)
            {
                y.go.SetActive(true);
            }
        }
    }
}
