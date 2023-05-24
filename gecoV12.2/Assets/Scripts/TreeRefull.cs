using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeRefull : MonoBehaviour
{
    // Start is called before the first frame update
      private PlayerContamination playerContamination;
      public float ContaminacionMitigada;
      
      public TextMeshProUGUI contaminacionMitigadaTXT;


    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
              playerContamination = FindObjectOfType<PlayerContamination>();

              ContaminacionMitigada += playerContamination.currentContamination;

              contaminacionMitigadaTXT.text = ContaminacionMitigada.ToString();

              playerContamination.currentContamination = 5f;
               


            }

    }
}
