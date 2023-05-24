using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectn1 : MonoBehaviour
{

    public Collider2D collider2d;
    public GameObject gameoverIMG;
  private void OnCollisionEnter2D(Collision2D collision) {
    
    if(collision.transform.CompareTag("Player"))
    {

            Time.timeScale = 0;
            gameoverIMG.SetActive(true);
            



    }
    
    
    
    }


  }

