using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] lines;
    public float textSpeed;

    private bool isPaused = false;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            } else {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
        
    }

    void StartDialogue()
    {
        index=0;
        StartCoroutine(TypeLine());
        isPaused = true;
    }
    
    IEnumerator TypeLine()
    {
        float startTime = Time.realtimeSinceStartup;
        float elapsedTime = 0f;

        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;

            while (elapsedTime < textSpeed)
            {
                elapsedTime = Time.realtimeSinceStartup - startTime;
                yield return null;
            }

            elapsedTime = 0f;
            startTime = Time.realtimeSinceStartup;
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            dialogueText.text = string.Empty;
            isPaused = false;
            Time.timeScale = 1f; 
            gameObject.SetActive(false);
        }
    }

    public void TriggerDialogueScore(int score) 
    {
        switch (score)
        {
            case 1:
                lines = new string[]
                {
                    "Los ciclones tropicales, como los huracanes, se están volviendo más poderosos debido al cambio climático.",
                    "Las aguas más cálidas y el aumento del contenido de humedad en el aire brindan más energía a estas tormentas."
                };
                break;

            case 2:
                lines = new string[]
                {
                    "El aumento de la temperatura del agua también está teniendo un impacto en los arrecifes de coral, uno de los ecosistemas más diversos del planeta.",
                    "Provoca el blanqueamiento de los corales, lo que puede llevar a su muerte y afectar a toda la cadena alimentaria marina."
                };
                break;

            case 3:
                lines = new string[]
                {
                    "Además de los huracanes, el cambio climático también está afectando a los glaciares.",
                    "Se están derritiendo a un ritmo alarmante, lo que contribuye al aumento del nivel del mar y pone en peligro a las especies que dependen de ellos, como los osos polares."
                };
                break;

            case 4:
                lines = new string[]
                {
                    "Las inundaciones son otro resultado directo del cambio climático.",
                    "El aumento del nivel del mar y la alteración de los patrones de lluvia resultan en eventos más intensos y frecuentes.",
                    "Las comunidades costeras están particularmente en riesgo."
                };
                break;

            case 5:
                lines = new string[]
                {
                    "El cambio climático también está relacionado con un aumento en la intensidad y frecuencia de las tormentas eléctricas.",
                    "El aumento de la temperatura y la humedad en la atmósfera puede generar tormentas más intensas y frecuentes."
                };
                break;

            case 6:
                lines = new string[]
                {
                    "Las sequías son otro efecto del cambio climático que estamos experimentando con mayor frecuencia.",
                    "Los períodos de sequía prolongados tienen graves consecuencias para la agricultura, el suministro de agua y los ecosistemas en general."
                };
                break;

            case 7:
                lines = new string[]
                {
                    "Las sequías disminuyen la humedad del suelo y hacen que los bosques sean más susceptibles al fuego.",
                    "Sin suficiente humedad, los árboles y la vegetación se vuelven más secos y combustibles, lo que facilita la propagación de los incendios."
                };
                break;

            case 8:
                lines = new string[]
                {
                    "El aumento de las temperaturas y las condiciones climáticas cambiantes pueden llevar al aumento de plagas y enfermedades que afectan a los bosques.",
                    "Por ejemplo, los escarabajos de corteza se reproducen más rápidamente en climas más cálidos, lo que puede debilitar los árboles y aumentar su susceptibilidad al fuego."
                };
                break;

            case 9:
                lines = new string[]
                {
                    "El calentamiento global puede afectar los ciclos de crecimiento de las plantas y la vegetación.",
                    "En algunas áreas, el aumento de las temperaturas y los cambios en los patrones de precipitación pueden favorecer un crecimiento más rápido de la vegetación.",
                    "Esto puede llevar a una mayor acumulación de biomasa, como hojas secas, ramas y otros materiales combustibles en el bosque.",
                    "Si estas acumulaciones no se limpian de manera natural, proporcionan una mayor cantidad de combustible para los incendios forestales."
                };
                break;

            case 10:
                lines = new string[]
                {
                    "Los incendios forestales también liberan grandes cantidades de gases de efecto invernadero a la atmósfera, incluido el dióxido de carbono.",
                    "Esta liberación de CO2 contribuye aún más al calentamiento global, creando así un ciclo de retroalimentación positiva.",
                    "A medida que el calentamiento global aumenta, aumenta el riesgo de incendios forestales, y a su vez, los incendios forestales emiten más gases de efecto invernadero, lo que acelera aún más el calentamiento."
                };
                break;

            default:
                lines = new string[]
                {
                    "Texto no encontrado."
                };
                break;
        }
        StartDialogue();
    }
    public void TriggerDialogue(string[] dialogue) 
    {
        lines = dialogue;
        StartDialogue();
    }
}
