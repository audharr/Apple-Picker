using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // This line enables use of uGUI classes like Text
using TMPro;           // Had to include this otherwise wouldn't work

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    // Private Text uiText;
     private TextMeshProUGUI uiText;  // Change this to TextMeshProUGUI - in order for the text to work and update

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();  // Use TextMeshProUGUI
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0");  // This 0 is a zero!
    }
}
