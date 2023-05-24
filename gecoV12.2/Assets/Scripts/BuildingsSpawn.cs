using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsSpawn : MonoBehaviour
{
   public GameObject EdificiosAtrasP2;
   public GameObject CasasFrenteP2;

   
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
            {
                EdificiosAtrasP2.SetActive(true);
                CasasFrenteP2.SetActive(true);
            }

    }
}
