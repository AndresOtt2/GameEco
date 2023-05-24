using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerContamination : MonoBehaviour
{
    public Image playerContaminationImage;
    public float currentContamination;
    public float maxContamination;
    public GameObject gameoverIMG;
    public GameObject monsters;

    public float ContaminacionAcumulada = 5f;

    



    void Update()
    {
        
       playerContaminationImage.fillAmount = (currentContamination/maxContamination);

        if(currentContamination>=(maxContamination/2))
        {
            monsters.SetActive(true);

        }else
        {
             monsters.SetActive(false);
        }

       if(currentContamination>=maxContamination)
       {
            //Time.timeScale = 0;
            //gameoverIMG.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameOver();
       }


             



    }
    void GameOver()
    {
        Time.timeScale = 0;
        gameoverIMG.SetActive(true);
    }

}
