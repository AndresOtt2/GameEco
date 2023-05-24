using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{

public GameObject transition;

    private void Update(){
        AllFruitsCollected();
    }

    //Si no tiene hijos, termina el nivel 
    public void AllFruitsCollected(){
        if(transform.childCount == 0){
            //Debug.Log("Nivel Terminado");
            transition.SetActive(true);
            Invoke("ChangeScene", 1);

        }
    }

    void ChangeScene(){

        Debug.Log(ControladorFinal.Instance.Recogidos());
        
    if(ControladorFinal.Instance.Recogidos()>1)
    {
        Debug.Log("entro");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);

    }else{

        Debug.Log("else");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
        
        
    }

}
