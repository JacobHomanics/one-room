using UnityEngine;
using DG.Tweening;
using TMPro;

public class AbilityWarner : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform position;

    public float distance;
    public float duration;
    public float delay;
    public void Warn(string message)
    {
        var textGameObject = Instantiate(textPrefab, this.transform);
        textGameObject.transform.position = transform.position;


        textGameObject.GetComponentInChildren<TMP_Text>().text = message;

        textGameObject.transform.DOMoveY(textGameObject.transform.position.y + distance, duration).SetDelay(delay);
        textGameObject.GetComponentInChildren<CanvasGroup>().DOFade(0, duration).SetDelay(delay).OnComplete(() => { Destroy(textGameObject); });
    }

}
