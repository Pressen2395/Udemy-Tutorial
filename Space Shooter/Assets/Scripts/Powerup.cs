/*
*Copyright (c) Pressen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]//0 = tripleshot 1 = speed 2 = sheilds
    private int _powerupId;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -2.5f)
		{
            Destroy(this.gameObject);
		}
    }

    //OnTriggerCollision
    //Collectable only by player
    //On collected Destroy
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
			{
				switch (_powerupId)
				{
                    case 0: 
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
					case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Default value");
                        break;
				}
              
			}
            Destroy(this.gameObject);
		}
	}
	
}
