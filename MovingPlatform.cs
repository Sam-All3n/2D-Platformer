using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Transform leftCheck, rightCheck;
    public float speed = 2f;
    RaycastHit2D leftGrounded, rightGrounded;
    int groundLayer;
    public int point = 100;
    Vector2 cDir;
    Rigidbody2D cRB;
    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");

        cRB = GetComponent<Rigidbody2D>();
        cDir = new Vector2(speed, 0f);
    }


    private void FixedUpdate()
    {
        leftGrounded = Physics2D.CircleCast(leftCheck.position, 0.2f, Vector2.down, 0f, groundLayer);
        rightGrounded = Physics2D.CircleCast(rightCheck.position, 0.2f, Vector2.down, 0f, groundLayer);

        if (!leftGrounded || !rightGrounded)
        {
            cDir = Vector2.Scale(cDir, new Vector2(-1f, 0f));
        }

        cRB.velocity = cDir;
    }
}
