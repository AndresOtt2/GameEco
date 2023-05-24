using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2d;
    public Animator animator;

    public SpriteRenderer spriterenderer;

    public GameObject destroyParticle;

    public float jumpforce = 2.5f;

    public int lifes = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*jumpforce);
        losselifeAndHit();
        CheckLife();


    }

public void losselifeAndHit()
{

    lifes--;
    animator.Play("Hit");



}

public void CheckLife()
    {

        if(lifes==0)
        {
            destroyParticle.SetActive(true);
            spriterenderer.enabled = false;
            Invoke("enemyDie",0.2f);

        }

        
        
    }
public void EnemyDie()
        {
                
                
                Destroy(gameObject);
                while(transform.childCount > 0)
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);

                }

            
        }

}
