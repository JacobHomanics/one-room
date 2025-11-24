using UnityEngine;

namespace JacobHomanics.Core.OverlapShape
{
	public class OverlapSphere : OverlapShape
	{
		[Header("Sphere")]
		public float radius = 1f;

		protected override void OverlapNonAlloc(Vector3 position)
		{
			Physics.OverlapSphereNonAlloc(position, radius, cols, layerMask);
		}

		protected override Collider[] Overlap(Vector3 position)
		{
			return Physics.OverlapSphere(position, radius, layerMask);
		}

		protected override void DrawBounds(Vector3 pos)
		{
			Gizmos.DrawWireSphere(pos, radius);
		}
	}
}
