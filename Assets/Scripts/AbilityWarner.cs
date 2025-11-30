using UnityEngine;
using DG.Tweening;
using TMPro;

public class AbilityWarner : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform position;

    public Transform startingPos;

    public float distance;
    public float duration;
    public float delay;

    public Vector3 destination;

    public void Warn(string message)
    {
        Warn(message, textPrefab);
    }

    public void Warn(string message, GameObject prefab)
    {
        var textGameObject = Instantiate(prefab, this.transform);

        if (!startingPos)
            textGameObject.transform.position = transform.position;
        else
            textGameObject.transform.position = startingPos.position;

        textGameObject.GetComponentInChildren<TMP_Text>().text = message;

        textGameObject.transform.DOMove(new Vector3(textGameObject.transform.position.x + destination.x, textGameObject.transform.position.y + destination.y, textGameObject.transform.position.z + destination.z), duration).SetDelay(delay);
        textGameObject.GetComponentInChildren<CanvasGroup>().DOFade(0, duration).SetDelay(delay).OnComplete(() => { Destroy(textGameObject); });
    }

}
