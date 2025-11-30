using UnityEngine;
using DG.Tweening;
using TMPro;

public class AbilityWarner2 : MonoBehaviour
{
    public GameObject goodPrefab;
    public GameObject badPrefab;

    public AbilityWarner abilityWarner;

    public void WarnGood(float value)
    {
        abilityWarner.Warn("+" + value.ToString("###"), goodPrefab);
    }

    public void WarnBad(float value)
    {
        abilityWarner.Warn("-" + value.ToString("###"), badPrefab);
    }

}
