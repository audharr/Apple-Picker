using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject poisonApplePrefab;

    // Speed at which AppleTree moves
    public float  speed = 1f;

    // Distance where AppleTree turns around
    public float  leftAndRightEdge = 10f;


    // Chance that the AppleTree will change directions
    public float  changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float  appleDropDelay = 1f;

    // Chance for a poisonApple
    public float poisonAppleChance = 0.1f;

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    // Start dropping apples
    Invoke("DropApple", 2f);    
}

void DropApple()
{
    // Generate a single random value
    float roll = Random.value;  

    // Only create ONE apple per drop
    GameObject appleToDrop;
    
    if (roll < poisonAppleChance) 
    {
        appleToDrop = poisonApplePrefab; // Drop a poison apple
        Debug.Log("Dropping Poison Apple");
    }
    else 
    {
        appleToDrop = applePrefab; // Drop a regular apple
        Debug.Log("Dropping Regular Apple");
    }

    // Instantiate and position the apple
    GameObject apple = Instantiate(appleToDrop);
    apple.transform.position = transform.position;

    // Continue dropping apples after a delay
    Invoke("DropApple", appleDropDelay);
}

// Update is called once per frame
void Update()
{
    // Basic Movement
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;

    // Changing Direction
    if(pos.x < -leftAndRightEdge) {
        speed = Mathf.Abs(speed);    // Move right
    }
    else if (pos.x > leftAndRightEdge) {
        speed = -Mathf.Abs(speed);   // Move left
    }
    //else if (Random.value < changeDirChance) {
    //    speed *= -1;
    //}
    }

void FixedUpdate() 
{
    // Random direction changes are now time-based due to FixedUpdate()
    if (Random.value < changeDirChance) {
        speed *= -1;    // Change direction
    }
}
    
}
