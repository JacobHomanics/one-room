using UnityEngine;

namespace JacobHomanics.Core.OverlapShape.Examples
{
    public class Movement : MonoBehaviour
    {
        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (1f * Time.deltaTime));
        }
    }
}