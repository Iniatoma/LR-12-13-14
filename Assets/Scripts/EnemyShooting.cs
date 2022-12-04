using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletrefab;
    public float fireDelay = 0.25f;
    int bulletLayer;
    float cooldownTimer = 0;
    Transform player;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            //find the player ship!
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null)
            {
                player = go.transform;

            }
        }
        cooldownTimer -= Time.deltaTime;
        if ( cooldownTimer <= 0 && player!= null && Vector3.Distance(transform.position,player.position)<4)//shoot!
        {
            Debug.Log("Enemy Pew!");
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGO= (GameObject)Instantiate(bulletrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
