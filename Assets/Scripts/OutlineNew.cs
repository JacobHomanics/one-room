using JacobHomanics.Essentials.RPGController;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineNew : MonoBehaviour
{
    [SerializeField] private RenderingLayerMask outlineLayer;

    private Renderer[] renderers;
    private uint originalLayer;
    private bool isOutlineActive;

    private void Start()
    {
        renderers = TryGetComponent<Renderer>(out var meshRenderer)
            ? new[] { meshRenderer }
            : GetComponentsInChildren<Renderer>();
        originalLayer = renderers[0].renderingLayerMask;
    }

    public void Set(bool enable)
    {
        foreach (var rend in renderers)
        {
            rend.renderingLayerMask = enable
            ? originalLayer | outlineLayer
            : originalLayer;
        }
    }
}