using UnityEngine;

namespace EssentialAssets.Core
{
    [RequireComponent(typeof(SpawnObject))]
    public class ActivatingObject: ObjectToExamine
    {
        public override void Interact()
        {
            base.Interact();
            GetComponent<SpawnObject>().EstablishSpawnAction();
        }
    }
}