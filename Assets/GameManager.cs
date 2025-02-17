using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI rounds;
    public Button restartButton;

    private int currentRound = 1;       // Always start at round 1
    private int maxRounds = 4;          // The max round is 4 because we only have 4 baskets
    private bool gameOver = false;      // Set false until it is true
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateRoundText();
        restartButton.gameObject.SetActive(false);      // Restart button won't appear
        restartButton.onClick.AddListener(RestartGame);
        
    }

    public void NextRound() {

        if (gameOver)
        return;

        currentRound++;

        if (currentRound > maxRounds) {
            GameOver();
        }
        else {
            UpdateRoundText();
        }
    }

    void UpdateRoundText() {
        rounds.text = "Round " + currentRound;
    }

    public void GameOver() {
        gameOver = true;
        rounds.text = "Game Over";
        restartButton.gameObject.SetActive(true);       // Restart button will display

        Time.timeScale = 0f;        // Supposed to pause game disabling movement
    }

    void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);         // Reloads the scene
    }
}