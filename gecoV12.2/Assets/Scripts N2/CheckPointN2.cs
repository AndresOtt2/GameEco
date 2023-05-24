using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointN2 : MonoBehaviour
{

    //Colisiona
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerRespawnN2>().ReachedCheckPoint(transform.position.x, transform.position.y);
            GetComponent<Animator>().enabled = true;
        }
    }
}
