using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitCollected : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerContamination playerContamination;   

    public TextMeshProUGUI contaminacionAcumuladaTXT;
    
    
    



    
    private void OnTriggerEnter2D(Collider2D collision) {
        

            if(collision.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject , 0.5f);

                ///
            

                playerHealth = FindObjectOfType<PlayerHealth>();
                playerContamination = FindObjectOfType<PlayerContamination>();


                if(playerHealth.currentHealth <= 100){    
                playerHealth.currentHealth += 30;}else
                {playerContamination.currentContamination += 3; }

                //Debug.Log(gameObject);

                    
                if(gameObject.name.Equals("nut"))
                {
                    playerContamination.currentContamination += 0.07f;
                    playerContamination.ContaminacionAcumulada += 0.07f;
                    

                }
                if(gameObject.name.Equals("eggs"))
                {
                    playerContamination.currentContamination += 3.24f;
                    playerContamination.ContaminacionAcumulada += 3.24f;
                    

                }
                if(gameObject.name.Equals("fishSteak"))
                {
                    playerContamination.currentContamination += 7.61f;
                    playerContamination.ContaminacionAcumulada += 7.61f;
                    

                }
                if(gameObject.name.Equals("meat"))
                {
                    playerContamination.currentContamination += 36.44f;
                    playerContamination.ContaminacionAcumulada += 36.44f;
                    
                }
                if(gameObject.name.Equals("Apple"))
                {
                    playerContamination.currentContamination += 0.9f;
                    playerContamination.ContaminacionAcumulada += 0.9f;
                    
                    
                }

                
                contaminacionAcumuladaTXT.text = playerContamination.ContaminacionAcumulada.ToString();
            }


    }

}
