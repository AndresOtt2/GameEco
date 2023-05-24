using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectedN2 : MonoBehaviour
{

private void OnTriggerEnter2D(Collider2D collision){
    //Si entra en contacto con el Tag 'Player'
    if(collision.CompareTag("Player")){
        //Dasactiva el objeto
        GetComponent<SpriteRenderer>().enabled = false;
        //Muestra la animacion 
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //Destruye el objeto y sus hijos
        Destroy(gameObject, 0.5f);
    }
}


}
