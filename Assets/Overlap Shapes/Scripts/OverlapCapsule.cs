using UnityEngine;

namespace JacobHomanics.Core.OverlapShape
{
    public class OverlapCapsule : OverlapShape
    {
        [Header("Capsule")]
        public float radius = 1f;
        public float height = 5f;

        protected override void OverlapNonAlloc(Vector3 position)
        {
            float halfHeight = Mathf.Max(0, (height - 2 * radius) / 2);
            Vector3 topSphereCenter = position + Vector3.up * halfHeight;
            Vector3 bottomSphereCenter = position - Vector3.up * halfHeight;

            Physics.OverlapCapsuleNonAlloc(bottomSphereCenter, topSphereCenter, radius, cols, layerMask);
        }

        protected override Collider[] Overlap(Vector3 position)
        {
            float halfHeight = Mathf.Max(0, (height - 2 * radius) / 2);
            Vector3 topSphereCenter = position + Vector3.up * halfHeight;
            Vector3 bottomSphereCenter = position - Vector3.up * halfHeight;

            return Physics.OverlapCapsule(bottomSphereCenter, topSphereCenter, radius, layerMask);
        }

        protected override void DrawBounds(Vector3 pos)
        {
            // Calculate capsule parameters
            float cylinderHeight = Mathf.Max(0, height - 2 * radius);
            Vector3 topSphereCenter = offset + Vector3.up * (cylinderHeight / 2);
            Vector3 bottomSphereCenter = offset - Vector3.up * (cylinderHeight / 2);

            // Draw top and bottom spheres
            Gizmos.DrawWireSphere(topSphereCenter, radius);
            Gizmos.DrawWireSphere(bottomSphereCenter, radius);

            // Draw connecting lines between spheres
            Gizmos.DrawLine(topSphereCenter + Vector3.forward * radius, bottomSphereCenter + Vector3.forward * radius);
            Gizmos.DrawLine(topSphereCenter - Vector3.forward * radius, bottomSphereCenter - Vector3.forward * radius);
            Gizmos.DrawLine(topSphereCenter + Vector3.right * radius, bottomSphereCenter + Vector3.right * radius);
            Gizmos.DrawLine(topSphereCenter - Vector3.right * radius, bottomSphereCenter - Vector3.right * radius);
        }
    }
}