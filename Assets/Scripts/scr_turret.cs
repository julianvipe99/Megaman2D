using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class scr_turret : MonoBehaviour
{
    public GameObject bulletpref;
    public GameObject player;
    private Animator Animator;
    private float LastShoot;
    Level level;
    [SerializeField] GameObject bullet_turret_empty;
    [SerializeField] GameObject bullet_turret_empty2;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.countEnemies();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 direction = player.transform.position - transform.position;
        }
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        Animator.SetBool("shoots", distance < 10.0f);

        if (distance < 10.0f && Time.time > LastShoot + 3f)
        {
            
            Shoot();
            LastShoot = Time.time;

        }   
    }
    private void Shoot()
    {

        GameObject bullet_turret = Instantiate(bulletpref, bullet_turret_empty.transform.position, Quaternion.identity);

        GameObject bullet_turret2 = Instantiate(bulletpref, bullet_turret_empty2.transform.position, Quaternion.identity);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            level.winLevel();
            Destroy(this.gameObject);
        }
    }
}
