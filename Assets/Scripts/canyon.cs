using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canyon : MonoBehaviour
{
    public bool banner = true;
    public GameObject bulletpref;
    public GameObject player;
    private Animator Animator;
    private float LastShoot;
    AudioSource myAudioSource;
    Level level;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip destruct;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.countEnemies();

        myAudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 direction = player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-7.410654f, 12.67443f, 1.0f);
        else transform.localScale = new Vector3(7.410654f, 12.67443f, 1.0f);

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        Animator.SetBool("dep", distance < 10.0f);

        if (distance < 10.0f && Time.time >LastShoot +3f)
        {
            Shoot();
            LastShoot = Time.time;
            
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        
        if (transform.localScale.x == -7.410654f) direction = Vector2.right;
        else direction =  Vector2.left;
        if (banner == true)
        {
            GameObject bullet = Instantiate(bulletpref, transform.position + direction * 3f, Quaternion.identity);
            bullet.GetComponent<bullet>().setDirection(direction);
            Debug.Log("Shoot");
            myAudioSource.PlayOneShot(fireSound);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hpta");
        if (collision.gameObject.CompareTag("laser"))
        {
            banner = false;
            StartCoroutine("destroy");
            myAudioSource.PlayOneShot(destruct);
        }
      
    }
    IEnumerator destroy()
    {
        Animator.SetBool("destroyed", true);
        yield return new WaitForSeconds(1);
        level.winLevel();
        Destroy(this.gameObject);

    }
   
}
