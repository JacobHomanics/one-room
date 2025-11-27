using UnityEngine;
using UnityEngine.Events;

namespace JacobHomanics.Utilities
{
    public class Action : MonoBehaviour
    {
        public UnityEvent OnInitiate;

        public void Initiate()
        {
            OnInitiate?.Invoke();
        }
    }
}
