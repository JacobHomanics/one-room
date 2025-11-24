using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerClickController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public UnityEvent<PointerEventData> PointerClicked;
    public UnityEvent<PointerEventData> LeftPointerClicked;
    public UnityEvent<PointerEventData> RightPointerClicked;

    public UnityEvent<PointerEventData> PointerEntered;
    public UnityEvent<PointerEventData> PointerExited;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEntered?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExited?.Invoke(eventData);
    }


    public void OnPointerClick(PointerEventData eventData)
    {

        PointerClicked?.Invoke(eventData);

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftPointerClicked?.Invoke(eventData);
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightPointerClicked?.Invoke(eventData);
        }
    }
}
