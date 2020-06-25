using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
 
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        
        if(transform.position.y >10)
        {
            //check if object has a parent destroy it too
            if (transform.parent != null)
			{
                Destroy(this.transform.parent.gameObject);// destroys both parent and child
			}
            Destroy(this.gameObject);
        }
    }
}
