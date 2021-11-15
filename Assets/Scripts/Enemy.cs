using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    [SerializeField] float range;
    [SerializeField] GameObject player;
    Level level;
    Rigidbody2D myBody;
    AIDestinationSetter aiDestination;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.countEnemies();
        aiDestination = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector2.Distance(player.transform.position, transform.position) <= range){
            Debug.Log("Sigalo y ataque >:v");
        }*/

        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player")) != null)
        {
            Debug.Log("ataca");
            aiDestination.target = player.transform;
        }else
        {
            aiDestination.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawSphere(transform.position, range);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            Destroy(this.gameObject);
            level.winLevel();
        }
    }
}
