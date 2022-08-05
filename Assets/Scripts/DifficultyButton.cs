using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }

    [SerializeField] private Difficulty difficulty;

    private Button _button;
    private GameManager _gameManager;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(difficulty);
    }
}