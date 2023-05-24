using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
[SerializeField] private float parallaxMultiplier;
   private Transform cameraTransform;
   private Vector3 previousCameraPos;
   private float startPosition, spritewidth;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPos = cameraTransform.position;
        spritewidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;

    }

    
    void Update()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPos.x)*parallaxMultiplier;
        float moveAmount = cameraTransform.position.x*(1-parallaxMultiplier);
       transform.Translate(new Vector3(deltaX,0,0));
        previousCameraPos = cameraTransform.position;
/*
        if(moveAmount > startPosition + spritewidth)
        {
             transform.Translate(new Vector3(spritewidth,0,0));
             startPosition += spritewidth;
        }else if(moveAmount < startPosition -spritewidth)
        {
            transform.Translate(new Vector3(-spritewidth,0,0));
            startPosition -= spritewidth;
        }*/
    }
}
