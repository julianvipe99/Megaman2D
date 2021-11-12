using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float range;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector2.Distance(player.transform.position, transform.position) <= range){
            Debug.Log("Sigalo y ataque >:v");
        }*/

       if( Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player"))!=null)
            Debug.Log("ataaacaaa");

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawSphere(transform.position, 1);
    }
}
