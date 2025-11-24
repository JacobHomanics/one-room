using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerAttackReceiver : MonoBehaviour
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Aye");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Aye2");

            FindAnyObjectByType<Attacker>().enabled = true;
        }
    }
}
