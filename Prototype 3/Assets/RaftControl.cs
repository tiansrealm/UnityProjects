using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftControl : MonoBehaviour {
    public float move_vel;
    private string mode = "stationary";
    Rigidbody2D rb;
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (mode == "stationary")
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (mode == "right")
        {
            rb.velocity = new Vector2(move_vel, rb.velocity.y);
        }
        else if (mode == "left")
        {
            rb.velocity = new Vector2(-move_vel, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mode = "right";
        }
    }
}
