using UnityEngine;

namespace JacobHomanics.Core.OverlapShape.Examples
{
    public class CastHandler : MonoBehaviour
    {
        public void HandleCast(Collider[] cols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                cols[i].GetComponent<Renderer>().material.color = randomColor;
            }
        }

        public void HandleCast(Collider col)
        {
            Destroy(col.gameObject);
        }

        public void OnStay(Collider col)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            col.GetComponent<Renderer>().material.color = randomColor;
        }
    }
}