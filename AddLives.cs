using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLives : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Info>().UpdateLives(1);
            Destroy(gameObject);
        }
    }
}
