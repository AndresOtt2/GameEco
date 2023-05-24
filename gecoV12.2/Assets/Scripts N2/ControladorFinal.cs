using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFinal : MonoBehaviour
{
    public static ControladorFinal Instance;
    [SerializeField] private float cantidad;

    private void Awake(){
        if(ControladorFinal.Instance == null){
            ControladorFinal.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else {
            Destroy(gameObject);
        }
    }

    public void Sumar(float puntos){
        cantidad += puntos;
    }   


    public float Recogidos()
    {
        return this.cantidad;

    }


    public void restar(float puntos)
    {

        cantidad -= puntos;

    }
}


