﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //move enemy down at 4m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if bottom of screen
        //respawn at top with a new random x position

        if(transform.position.y < -2.5f)
        {
            transform.position = new Vector3(Random.Range(-9.45f,9.45f), 10, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit player
        //destroy player
        //destroy us

        if(other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
                player.Damage();
            Destroy(this.gameObject);
        }

        //if hit laser
        //destroy laser
        //destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
     
    }
}
