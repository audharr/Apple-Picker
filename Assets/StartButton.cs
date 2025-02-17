using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Function to load the game scene
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Scene_0");
    }
}