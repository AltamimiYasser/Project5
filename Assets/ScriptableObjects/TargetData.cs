using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class TargetData : ScriptableObject
    {
        public float maxSpeed = 16;
        public float minSpeed = 12;
        public float torqueRange = 10;
        public float xRange = 4;
        public float ySpawnPosition = -6;
    }
}

// TODO: On GameOver screen show the current score and the highest score and tell user if the current is his highest
// TODO: Implement pooling
// TODO: Implement blade slicing