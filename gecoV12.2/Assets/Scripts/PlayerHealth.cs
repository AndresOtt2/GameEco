using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Image playerHealthImage;

    public float currentHealth;

    public float maxHealth;

    public GameObject gameoverIMG;
    public GameObject WinIMG;


    
void Start() {
    
    Time.timeScale = 1;
    gameoverIMG.SetActive(false);
    WinIMG.SetActive(false);


        }
    


    void Update()
    {
        if(currentHealth>=1)
        {
            currentHealth -= (5*Time.deltaTime);
            playerHealthImage.fillAmount = (currentHealth/maxHealth);
        }
        
        

        if(currentHealth<1)
        {

            //Time.timeScale = 0;
            //gameoverIMG.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameOver();

        }
    }

    void GameOver(){

            Time.timeScale = 0;
            gameoverIMG.SetActive(true);

    }
}
