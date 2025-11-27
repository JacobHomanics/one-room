using UnityEngine;
using DG.Tweening;
using TMPro;
using JacobHomanics.HealthSystem;
using DG.Tweening.Core.Easing;

public class HealthDamageDisplayer : MonoBehaviour
{
    public GameObject textPrefab;
    public Health health;

    public float distanceY;
    public float distanceX;

    public float duration;
    public Ease ease;

    void OnEnable()
    {
        health.OnHealthDown.AddListener(Do);
    }

    void OnDisable()
    {
        health.OnHealthDown.RemoveListener(Do);

    }
    public void Do(float value)
    {
        var textGameObject = Instantiate(textPrefab);
        textGameObject.transform.position = transform.position;


        // Calculate fixed distance from current distanceX and distanceY
        float fixedDistance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);

        // Randomize direction (random angle in radians)
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        // Calculate x and y offsets using the fixed distance and random angle
        float x = Mathf.Cos(randomAngle) * fixedDistance;
        float y = Mathf.Sin(randomAngle) * fixedDistance;



        textGameObject.GetComponentInChildren<TMP_Text>().text = value.ToString("##");

        textGameObject.transform.DOMoveY(textGameObject.transform.position.y + y, duration).SetEase(ease);
        textGameObject.transform.DOMoveX(textGameObject.transform.position.x + x, duration).SetEase(ease);
        textGameObject.GetComponentInChildren<CanvasGroup>().DOFade(0, duration).SetEase(ease).OnComplete(() => { Destroy(textGameObject); });
        // textGameObject.transform.DOScale(new Vector3(0, 0, 0), duration);
    }
}
