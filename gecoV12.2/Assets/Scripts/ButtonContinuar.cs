using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonContinuar : MonoBehaviour 
{
    public GameObject gameoverIMG;
    // Start is called before the first frame update
    
    public void ButtonFunction()
    {
        Scene scene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(scene.buildIndex+1);
        
        
        
        
       
    }
}
