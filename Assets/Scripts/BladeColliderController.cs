using UnityEngine;

public class BladeColliderController : MonoBehaviour
{
    private Collider _collider;
    private bool _isMouseDown;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void Update()
    {
        _collider.enabled = Input.GetMouseButton(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // So the player doesn't just hold the left mouse button and keep clicking on targets
        Destroy(gameObject);
    }
}