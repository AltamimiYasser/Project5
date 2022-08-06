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

// TODO: Implement pooling
// TODO: Add SFX when using blade