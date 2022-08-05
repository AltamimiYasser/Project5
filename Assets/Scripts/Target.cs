using ScriptableObjects;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetData data;

    // the point it will add or deduct from the score
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private GameManager _gameManager;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(GetRandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(GetRandomTorque(), ForceMode.Impulse);
        transform.position = GetRandomPosition();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        OnPlayerHitTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Sensor"))
            return;
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad")) _gameManager.DeductLive();
    }

    private void OnPlayerHitTarget()
    {
        if (_gameManager.GameIsPaused || !_gameManager.GameIsActive) return;

        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        _gameManager.UpdateScore(pointValue);
    }

    private Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(data.minSpeed, data.maxSpeed);
    }

    private Vector3 GetRandomTorque()
    {
        return new Vector3(
            Random.Range(-data.torqueRange, data.torqueRange),
            Random.Range(-data.torqueRange, data.torqueRange),
            Random.Range(-data.torqueRange, data.torqueRange)
        );
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-data.xRange, data.xRange), data.ySpawnPosition, 0);
    }
}