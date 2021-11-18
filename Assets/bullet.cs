using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   
    public float Speed;
   
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public GameObject canyon;
    private Transform canyonTrans;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        canyonTrans = canyon.transform;

       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Direction==Vector2.left )
        {
            transform.localScale = new Vector3(8, 8, 8);

        }
        if (Direction == Vector2.right)
        {
            transform.localScale = new Vector3(-8, 8, 8);

        }
        Rigidbody2D.velocity = Direction * Speed;
       
        Debug.Log("Value= " + Direction);
    }

    public void setDirection(Vector2 direction)
    {
        Direction = direction;
       
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
