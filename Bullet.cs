using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector2 dir;
    Rigidbody2D rb;
    public bool harmPlayer, harmEnemy;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
	}


    private void FixedUpdate()
    {
        rb.velocity = dir;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && harmEnemy)
        {
            collision.gameObject.GetComponent<Enemy>().BeenHit();
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Enemy" && harmPlayer)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Info>().DeathReset();
        }
        
    }
}
