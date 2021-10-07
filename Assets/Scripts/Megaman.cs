using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    AudioSource myAudioSource;

    [SerializeField] GameObject laser;
    [SerializeField] GameObject gun;
    bool sRight;
    bool sLeft;
    float canFire;
    bool doubleJump;
    [SerializeField] float nextFire=0.5f;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip fireSound;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myAudioSource = GetComponent<AudioSource>();

        sRight = true;
        sLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

        move();
        jump();
        falling();
        fire();
        
    }

    void move()
    {
        float mov = Input.GetAxis("Horizontal");

        if (mov != 0)
        {
            myAnimator.SetBool("running", true);
            transform.localScale = new Vector2(Mathf.Sign(mov), 1);
            transform.Translate(new Vector2(mov * speed * Time.deltaTime, 0));
            if (Mathf.Sign(mov) == 1)
            {   
                sRight = true;
                sLeft = false;
                laser.GetComponent<laser>().setDirec(sRight, sLeft);
            }
            else
            {
                sLeft = true;
                sRight = false;
                laser.GetComponent<laser>().setDirec(sRight, sLeft);
            }
        }
        else
        {
            myAnimator.SetBool("running", false);
        }
    }

    void jump()
    {
        
        if ( !myAnimator.GetBool("jumping"))

        {
            
            myAnimator.SetBool("jumping", false);
            myAnimator.SetBool("falling", false);


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                doubleJump = true;
                myAnimator.SetTrigger("takeOf");
                myBody.velocity = new Vector2(myBody.velocity.x, jumpSpeed);
                myAudioSource.PlayOneShot(jumpSound);

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))

                {
                    if (doubleJump)
                    {

                        myBody.velocity = new Vector2(myBody.velocity.x, jumpSpeed);
                        myAnimator.SetTrigger("takeOf");
                        myAudioSource.PlayOneShot(jumpSound);
                        doubleJump = false;
                    }
                }
            }
        }     
    }

   

    void falling()
    {
        if (myBody.velocity.y < 0 && !myAnimator.GetBool("jumping"))
            myAnimator.SetBool("falling", true);
    }



    bool isGrounded()
    {
        RaycastHit2D myRaycast = Physics2D.Raycast(myCollider.bounds.center, Vector2.down, myCollider.bounds.extents.y + 0.2f, LayerMask.GetMask("Ground"));
        return myRaycast.collider != null;
    }

    void afterTakeOfEvent()
    {
        myAnimator.SetBool("jumping", false);
        myAnimator.SetBool("falling", true);
    }

    void fire()
    {
        if (Input.GetKey(KeyCode.X))
        {
            myAnimator.SetLayerWeight(1, 1f);
            fireLaser();
        }
        else
            myAnimator.SetLayerWeight(1, 0f);
    }

    void fireLaser()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= canFire)
        {
            Instantiate(laser, gun.transform.position , Quaternion.identity);
            myAudioSource.PlayOneShot(fireSound);
            canFire = nextFire + Time.time;
        }
    }
}
