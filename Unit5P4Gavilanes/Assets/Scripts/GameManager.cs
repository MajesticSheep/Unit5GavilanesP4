using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    public TextMeshProUGUI livesText;
    public int lives;

    public GameObject pauseMenuUI;
    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;

        //Offset -1 in the UpdateLives()
        lives++;
        UpdateLives();
    }

    public void UpdateLives()
    {
        if (isGameActive)
        {
            lives--;
            livesText.text = "Lives: " + lives;

            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gamePaused)
            {
                if (gamePaused == false)
                {
                    gamePaused = false;
                    Time.timeScale = 1f;
                    pauseMenuUI.SetActive(false);
                    isGameActive = true;
                }
                
                
            }

            else if (Input.GetKeyDown(KeyCode.Space) && isGameActive)
                {
                    if (!gamePaused)
                    {
                        Time.timeScale = 0f;
                        pauseMenuUI.SetActive(true);
                        gamePaused = true;
                        isGameActive = false;
                    }
                }

        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
