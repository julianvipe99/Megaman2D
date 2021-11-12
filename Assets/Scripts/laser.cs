using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField]bool right, left;
    Animator myAnimator;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        direction(right, left);
    }

    void direction(bool r, bool l)
    {
        if(r==true && l==false)
            myBody.velocity=Vector2.right * speed ;
        else
            myBody.velocity=Vector2.left * speed ;

    }

    public void setDirec(bool r, bool l)
    {
        right = r;
        left = l;

    }

    IEnumerator laserImpact()
    {
        speed = 0;
        myAnimator.SetTrigger("explode");
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(laserImpact());
        }

        Debug.Log(collision);
        
    }




}
