using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
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
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }



}
