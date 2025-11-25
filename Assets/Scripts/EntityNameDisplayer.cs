using TMPro;
using UnityEngine;

public class EntityNameDisplayer : MonoBehaviour
{
    public Entity entity;

    public TMP_Text text;

    void Update()
    {
        text.text = entity.value;
    }
}
