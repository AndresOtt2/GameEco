using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public ScoreManager scoreManager;
    // Reference to the UI Panel containing the DialogueScript component
    public GameObject dialoguePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkForFinishLevel()
    {
        if(scoreManager.GetScore() < 1) {
            dialoguePanel.gameObject.SetActive(true);
            DialogueScript dialogueScript = dialoguePanel.GetComponentInChildren<DialogueScript>();
            if (dialogueScript != null)
            {
                string[] lines = new string[] { "Aun te faltan algunas cajas!", "No podemos irnos sin al menos haber conseguido 8!" };
                dialogueScript.TriggerDialogue(lines);
            }
        } else {
            dialoguePanel.gameObject.SetActive(true);
            DialogueScript dialogueScript = dialoguePanel.GetComponentInChildren<DialogueScript>();
            if (dialogueScript != null)
            {
                string[] lines = new string[] { "!Bien Hecho!", "Gracias por haberme rescatado y ayudarme a recuperar las cajas.", "Ahora podremos continuar con la misión." };
                dialogueScript.TriggerDialogue(lines);
            }
            SceneManager.LoadScene(0);
        }
    }
}
