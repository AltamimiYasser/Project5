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

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject titleScreen;

    private int _score;

    public bool GameIsActive { get; private set; }

    public void StartGame(DifficultyButton.Difficulty difficulty)
    {
        maxSpawnRate /= (float)difficulty;
        minSpawnRate /= (float)difficulty;
        _score = 0;
        GameIsActive = true;
        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnTargets());
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        GameIsActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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