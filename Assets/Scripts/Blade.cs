using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private GameObject bladeTrailPrefab;
    private Camera _cam;
    private GameObject _currentBladeTrail;

    private GameManager _gameManager;

    private bool _isCutting;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (!_gameManager.GameIsActive || _gameManager.GameIsPaused) return;

        if (Input.GetMouseButtonDown(0)) StartCutting();
        else if (Input.GetMouseButtonUp(0)) StopCutting();

        if (_isCutting) UpdateCut();
    }

    private void UpdateCut()
    {
        _rigidbody.position = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StartCutting()
    {
        _isCutting = true;
        _currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
    }

    private void StopCutting()
    {
        _isCutting = false;

        if (_currentBladeTrail)
            _currentBladeTrail.transform.SetParent(null);

        Destroy(_currentBladeTrail, 2f);
    }
}