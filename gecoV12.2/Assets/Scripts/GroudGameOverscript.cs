using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudGameOverscript : MonoBehaviour
{
        public GameObject gameoverIMG;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) 
    {

            if(collision.CompareTag("Player"))
            {
            Time.timeScale = 0;
            gameoverIMG.SetActive(true);
            }
    }

}
