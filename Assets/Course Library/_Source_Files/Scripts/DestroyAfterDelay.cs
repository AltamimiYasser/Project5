using UnityEngine;

namespace Course_Library._Source_Files.Scripts
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Destroy(gameObject, 2);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}