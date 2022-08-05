using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;
    [SerializeField] private int maxLives = 3;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject titleScreen;

    private int _lives;
    private int _score;
    public bool GameIsPaused { get; private set; }

    public bool GameIsActive { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GameIsPaused = !GameIsPaused;

        Time.timeScale = GameIsPaused ? 0 : 1;
    }

    public void StartGame(DifficultyButton.Difficulty difficulty)
    {
        maxSpawnRate /= (float)difficulty;
        minSpawnRate /= (float)difficulty;
        _score = 0;
        _lives = maxLives;
        GameIsActive = true;
        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnTargets());
        UpdateScore(0);

        scoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = _score.ToString();
    }

    public void DeductLive()
    {
        _lives--;
        livesText.text = ConstructLivesText();
        livesText.color = GetLivesColor();
        if (_lives == 0) GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private Color GetLivesColor()
    {
        return _lives switch
        {
            2 => new Color(0.78f, 0.33f, 0f),
            _ => new Color(0.68f, 0.01f, 0f)
        };
    }

    private string ConstructLivesText()
    {
        return _lives switch
        {
            1 => _lives + " life",
            _ => _lives + " lives"
        };
    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        livesText.gameObject.SetActive(false);
        GameIsActive = false;
    }

    private IEnumerator SpawnTargets()
    {
        while (GameIsActive)
        {
            var waitRate = Random.Range(minSpawnRate, maxSpawnRate);

            yield return new WaitForSeconds(waitRate);
            var randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets[randomIndex]);
        }
    }
}