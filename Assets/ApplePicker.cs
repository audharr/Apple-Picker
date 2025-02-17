using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numbaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numbaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

public void AppleMissed(GameObject apple)
{
    // Destroy all falling apples
    GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
    foreach(GameObject tempGO in appleArray) {
        Destroy(tempGO);
    }

    // Destroy one of the baskets
    if (basketList.Count > 0) {
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // Tell GameManager to update the round
        FindFirstObjectByType<GameManager>().NextRound();
    }

    // If there are no baskets left, restart the game
    if (basketList.Count == 0) {
        FindFirstObjectByType<GameManager>().GameOver(); // Call Game Over instead of reloading
    }
}

    public void PoisonAppleCaught()
    {
        // Handle the poison apple catching scenario (game over)
        FindFirstObjectByType<GameManager>().GameOver();  // Trigger game over if a poison apple is caught
    }
}