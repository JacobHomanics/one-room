using UnityEngine;

public class EnemyDeathPowerupSpawner : MonoBehaviour
{
    public GameObject pickup1;
    public GameObject pickup2;

    public float baseDropPercentage;

    public void Spawn()
    {
        var rn = Random.Range(0f, 1f);
        if (rn <= (baseDropPercentage / 100f))
        {
            var rn2 = Random.Range(0f, 1f);

            if (rn2 <= .5f)
            {
                var go = Instantiate(pickup1);
                go.transform.position = transform.position;
            }

            if (rn2 > .5f)
            {
                var go = Instantiate(pickup2);
                go.transform.position = transform.position;
            }
        }


    }

}
