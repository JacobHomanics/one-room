using JacobHomanics.HealthSystem;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float amount;
    public float variancePercentage;

    public bool isShield;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!isShield)
            {
                var diff = amount * (variancePercentage / 100f);
                var rn = Random.Range(amount - diff, amount + diff);
                other.transform.root.GetComponentInChildren<Health>().Heal(rn);
            }

            else
            {
                var diff = amount * (variancePercentage / 100f);
                var rn = Random.Range(amount - diff, amount + diff);
                other.transform.root.GetComponentInChildren<Health>().RestoreShield(rn);
            }

            Destroy(this.gameObject);
        }
    }
}
