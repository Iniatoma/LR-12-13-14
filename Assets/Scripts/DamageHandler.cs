using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public  int health = 1;
    public float invulnPeriod = 0;

    float invulnTimer = 0.50f;
    int correctLayer;
    
    SpriteRenderer spriteRend;
    void Start()
    {
        correctLayer = gameObject.layer;
        //NOTE this only get the renderer on the parent object 
        //In other words, it doesn t work for children Y.E. "Enemy"
        spriteRend = GetComponent<SpriteRenderer>();
        if(spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
        }
        if (spriteRend==null)
        {
            Debug.LogError("Object" + gameObject.name + "has no sprite renderer");
        }
    }
    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");
            health--;
        if(invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;

            gameObject.layer = 8;
        }
           
        
        
    }
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if(spriteRend!=null)
                {
                    spriteRend.enabled = true;

                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;

                }
            }
            if (health <= 0)
            {
                Die();
            }
        }

    }
    void Die()
    {
        Destroy(gameObject);
    }
}

