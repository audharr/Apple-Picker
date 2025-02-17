using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float  bottomY = -20f;
    public bool isPoisonApple = false;  // Flag to indicate if this is a poison apple

    void Update() {
        if (transform.position.y < Apple.bottomY) {
            if (CompareTag("Apple")) {  
                // Only regular apples cause a basket to be lost
                Debug.Log("Missed Regular Apple! Losing a Basket.");
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleMissed(this.gameObject);  
            }
            else if (CompareTag("PosionApple")) {
                // Poison apples do nothing when missed
                Debug.Log("Missed Poison Apple! No penalty.");
            }

            Destroy(this.gameObject);  // Remove the apple after processing
        }
    }
}