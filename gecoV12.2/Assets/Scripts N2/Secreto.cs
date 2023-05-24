using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secreto : MonoBehaviour
{
    [SerializeField] private float puntos;

    private void OnTriggerEnter2D(Collider2D collision){
    //Si entra en contacto con el Tag 'Player'
    if(collision.CompareTag("Player")){
        ControladorFinal.Instance.Sumar(puntos);
    }
}
}
