using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public GameObject[] Fish;
    float timer;                                // Timer for counting up to the next fish.
    [SerializeField]
    float timeBetweenFish;
    GameObject currentPoint;
    int index;

    private void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenFish)
        {
            // ... attack.
            Spawn();
        }
    }
    void Spawn()
    {
        // Reset the timer.
        timer = 0f;
        index = Random.Range(0, Fish.Length);
        ActivateFish();
    }
    void ActivateFish()
    {
        Fish[index].SetActive(true);
    }
}
