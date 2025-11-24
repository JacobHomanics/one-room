using UnityEngine;
using UnityEngine.Events;

namespace JacobHomanics.Core.OverlapShape
{
    public class OverlapShapeEvents : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent<Collider[]> OnCast = new();
        public UnityEvent<Collider[]> OnCastHit = new();
        public UnityEvent<Collider> OnEnter = new();
        public UnityEvent<Collider> OnStay = new();
        public UnityEvent<Collider> OnExit = new();

    }
}