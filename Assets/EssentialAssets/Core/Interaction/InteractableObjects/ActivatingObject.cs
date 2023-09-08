using UnityEngine;
using Core;

namespace Interaction
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