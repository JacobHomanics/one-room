using UnityEngine;

namespace JacobHomanics.Core.OverlapShape.Examples
{
    public class OverlapShapeCaster : MonoBehaviour
    {
        public OverlapShape shape;

        void Update()
        {
            shape.Cast();
        }
    }
}