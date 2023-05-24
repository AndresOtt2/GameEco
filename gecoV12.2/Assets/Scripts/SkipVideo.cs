using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
         Scene scene = SceneManager.GetActiveScene();
         

        if(scene.buildIndex == 12 || scene.buildIndex == 13 )
        {
            SceneManager.LoadScene(0);
        }else
        {   

            SceneManager.LoadScene(scene.buildIndex+1);

        }

        }
    }
}
