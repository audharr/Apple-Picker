using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use TextMeshPro namespace

public class HighScore : MonoBehaviour
{
    // Had to do differently in order for the score to update
    private TextMeshProUGUI _UI_TEXT;  // Reference to TextMeshProUGUI component
    private static int _SCORE = 1000;  // Static score, will persist across scenes

    void Awake() {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();  // Assign the TextMeshProUGUI component to the variable
        UpdateHighScoreUI();  // Update the UI when the game starts

        // Load the high score from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Save the high score to PlayerPrefs
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    // Static property for the high score
    public static int SCORE {
        get { return _SCORE; }
        set {
            // Update the static score and UI when the value changes
            if (value > _SCORE) {
                _SCORE = value;

                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", value);

                // Find the instance of HighScore and update the UI text
                HighScore instance = FindFirstObjectByType<HighScore>();
                if (instance != null && instance._UI_TEXT != null) {
                    instance.UpdateHighScoreUI();
                }
            }
        }
    }

    // Method to update the high score UI text
    private void UpdateHighScoreUI() {
        if (_UI_TEXT != null) {
            _UI_TEXT.text = "High Score: " + _SCORE.ToString("#,0");
        }
    }

    // Method to try and set the high score
    public static void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry > _SCORE) {
            SCORE = scoreToTry;  // This will trigger the UI update if the score is higher
        }
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }
}