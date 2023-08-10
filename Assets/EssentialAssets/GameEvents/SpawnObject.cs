using UnityEngine;

namespace Interaction
{
    public class SpawnObject : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject[] objectsToSpawn;
        [SerializeField] private GameObject[] objectsToHide;
        
        [Header("Spawn Specifications")]
        [SerializeField] private SpawnSpecs spawnSpecs;

        private bool _isObjectActive = true;

        private enum SpawnSpecs
        {
            Repeating,
            OneTime
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!_isObjectActive) return;
            EstablishSpawnAction();
        }

        public void EstablishSpawnAction()
        {
            switch (spawnSpecs)
            {
                case SpawnSpecs.OneTime:
                    PerformSpawning();
                    _isObjectActive = false;
                    break;
                case SpawnSpecs.Repeating:
                    PerformSpawning();
                    break;
            }
        }

        private void PerformSpawning()
        {
            foreach (var spawnObject in objectsToSpawn) spawnObject.SetActive(true);
            foreach (var hideObject in objectsToHide) hideObject.SetActive(false);
        }
    }
}
