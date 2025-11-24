using UnityEngine;

namespace JacobHomanics.Core.OverlapShape
{
	public class OverlapCube : OverlapShape
	{
		[Header("Cube")]
		public Vector3 halfExtents = Vector3.one;

		public Vector3 BoxSize
		{
			get { return halfExtents * 2f; }
		}

		protected override void OverlapNonAlloc(Vector3 position)
		{
			Physics.OverlapBoxNonAlloc(position, halfExtents, cols, transform.rotation, layerMask);
		}

		protected override Collider[] Overlap(Vector3 position)
		{
			return Physics.OverlapBox(position, halfExtents, transform.rotation, layerMask);
		}

		protected override void DrawBounds(Vector3 pos)
		{
			Gizmos.DrawWireCube(pos, BoxSize);
		}
	}
}