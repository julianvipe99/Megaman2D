using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField]bool right, left;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        direction(right, left);
    }

    void direction(bool r, bool l)
    {
        if(r==true && l==false)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    public void setDirec(bool r, bool l)
    {
        right = r;
        left = l;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {
            transform.Translate(Vector2.zero*Time.deltaTime);
            myAnimator.SetTrigger("explode");
            Destroy(this.gameObject,0.5f);
        }

        Debug.Log(collision);
        
    }




}
