using UnityEngine;

namespace Pickable
{
    public class Pickable : MonoBehaviour
    {
        protected void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            PickingBehaviour();
        }

        protected virtual void PickingBehaviour()
        {
            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}