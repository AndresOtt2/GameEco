using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangariM : MonoBehaviour
{
    public GameObject NextLevel;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            NextLevel.SetActive(true);
        }
    }

}
