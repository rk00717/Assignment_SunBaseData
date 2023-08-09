using UnityEngine;
using com.RKode.Helper;

namespace com.RKode{
    public class Spawner : MonoBehaviour {
        [SerializeField] private GameObject dotPrefab;
        [SerializeField, Range(0, 100)] private int spawnCount = 5;

        private void Start() {
            for(int i=0; i<spawnCount; i++){
                Vector2 spawnPosition = (Vector2) transform.position + (Random.insideUnitCircle * 3f);

                Instantiate(dotPrefab, spawnPosition, Quaternion.identity, null);
            }
        }
    }
}