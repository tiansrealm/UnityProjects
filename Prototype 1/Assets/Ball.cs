using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float maxSpeed = 15;
    public float minSpeed = 3;
    private Rigidbody2D rb;

    void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        if(rb.velocity.magnitude < minSpeed) {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
    }
}
