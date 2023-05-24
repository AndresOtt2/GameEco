using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class CheckPoint : MonoBehaviour
{
public GameObject WinIMG;
public FruitCollected info;
public TreeRefull info2;
   //public TextMesh Victory;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") )
        {
            GetComponent<Animator>().enabled=true;
            //Victory.gameObject.SetActive(true);
            //SceneManager.LoadScene(3);
             //Time.timeScale = 0;
             WinIMG.SetActive(true);
    /*         
       

*/

    }





        }
    }

