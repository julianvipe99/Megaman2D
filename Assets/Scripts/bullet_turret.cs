using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_turret : MonoBehaviour
{

    public float Speed=10;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public GameObject turret;
    private Transform canyonTrans;
  
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        



    }

    // Update is called once per frame
    void Update()
    {
        

        Rigidbody2D.velocity = new Vector3 (Speed* Time.deltaTime, Speed * Time.deltaTime,0) ;

        Debug.Log("Value= " + Direction);
    }

   


    public void DestroyBullet()
    {
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject)
        {
            Destroy(gameObject);
        }
    }
}

