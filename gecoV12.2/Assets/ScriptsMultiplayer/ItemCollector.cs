using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private ScoreManager scoreManager;
    private int collectedItemCount = 0;
    public Text scoreText;

    private void Start()
    {
        // Find the ScoreManager script gameObject in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            // Disable the collected box object
            collision.gameObject.SetActive(false);

            // Increase the collected item count through the ScoreManager script
            scoreManager.IncreaseScore();
            // Display the updated count
            Debug.Log("Collected: " + collectedItemCount + " boxes");
        }
    }
}
