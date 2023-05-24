using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;
    // Reference to the UI Panel containing the DialogueScript component
    public GameObject dialoguePanel;

    private void Start()
    {
        // Update the UI text with the initial score
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        // Increase the score by 1
        score++;
        // Update the UI text with the new score
        UpdateScoreText();
        // Trigger dialogue based on the score value
        dialoguePanel.gameObject.SetActive(true);
        DialogueScript dialogueScript = dialoguePanel.GetComponentInChildren<DialogueScript>();
        if (dialogueScript != null)
        {
            dialogueScript.TriggerDialogueScore(score);
        }
    }

    public int GetScore()
    {
        // Return the current score
        return score;
    }

    private void UpdateScoreText()
    {
        // Update the UI text with the current score
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score + " boxes");
    }
}