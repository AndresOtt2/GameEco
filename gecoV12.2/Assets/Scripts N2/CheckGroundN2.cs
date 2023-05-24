using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundN2 : MonoBehaviour
{
    public static bool isGrounded;

    //Hace colision
    private void OnTriggerEnter2D(Collider2D collision){
        isGrounded = true;
    }

    //Deja de hacer colision 
    private void OnTriggerExit2D(Collider2D collision){
        isGrounded = false;
    }
}
