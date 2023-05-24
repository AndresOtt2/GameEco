using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    [SerializeField] private HydrationMechanic controller;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            controller.Hidratacion(5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
