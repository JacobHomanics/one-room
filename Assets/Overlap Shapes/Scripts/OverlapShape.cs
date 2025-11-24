using UnityEngine;

namespace JacobHomanics.Core.OverlapShape
{
	public abstract class OverlapShape : MonoBehaviour
	{
		[Header("Settings")]
		public Vector3 offset = Vector3.zero;
		public LayerMask layerMask = ~0;
		public enum AllocType { Alloc, NonAlloc }

		protected Collider[] cols;

		public int preAllocateAmount = 0;

		protected Collider[] _previousColliders = new Collider[0];

		[Header("Optional")]
		public OverlapShapeEvents events;

		void Start()
		{
			if (preAllocateAmount > 0)
				cols = new Collider[preAllocateAmount];
		}

		protected abstract Collider[] Overlap(Vector3 position);

		protected abstract void OverlapNonAlloc(Vector3 position);

		public Collider[] Cast()
		{
			var position = CalculatePosition(offset);

			if (preAllocateAmount > 0)
			{
				OverlapNonAlloc(position);
				HandleCastEvents(cols);
				return cols;
			}
			else
			{
				var cols = Overlap(position);
				HandleCastEvents(cols);
				return cols;
			}
		}

		protected Vector3 CalculatePosition(Vector3 offset)
		{
			var local = this.transform.TransformPoint(offset);
			var diff = this.transform.position - local;
			var pos = this.transform.position - diff;

			return pos;
		}

		protected void HandleCastEvents(Collider[] _currentColliders)
		{
			if (events == null) return;

			for (int x = 0; x < _currentColliders.Length; x++)
			{
				bool isNew = true;
				for (int y = 0; y < _previousColliders.Length; y++)
				{
					if (_currentColliders[x] == _previousColliders[y])
					{
						isNew = false;
						break;
					}
				}
				if (isNew)
					events.OnEnter?.Invoke(_currentColliders[x]);
				else
					events.OnStay?.Invoke(_currentColliders[x]);
			}

			for (int x = 0; x < _previousColliders.Length; x++)
			{
				bool isStillPresent = false;
				for (int y = 0; y < _currentColliders.Length; y++)
				{
					if (_previousColliders[x] == _currentColliders[y])
					{
						isStillPresent = true;
						break;
					}
				}
				if (!isStillPresent)
				{
					events.OnExit?.Invoke(_previousColliders[x]);
				}
			}

			_previousColliders = _currentColliders;

			if (_currentColliders.Length > 0)
				events.OnCastHit?.Invoke(_currentColliders);

			events.OnCast?.Invoke(_currentColliders);
		}

		protected abstract void DrawBounds(Vector3 pos);

		private void OnDrawGizmos()
		{
			Color prevColor = Gizmos.color;
			Gizmos.color = boundsColor;

			Matrix4x4 prevMatrix = Gizmos.matrix;

			Gizmos.matrix = transform.localToWorldMatrix;

			if (showBounds)
				DrawBounds(offset);

			Gizmos.matrix = prevMatrix;

			Gizmos.color = prevColor;
		}

		[Header("Debug")]
		public Color boundsColor = Color.red;
		public bool showBounds = true;
	}
}