using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Control : MonoBehaviour {
    public float max_velocity;
    private Rigidbody2D rb;
    public bool is_boosted = false;
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        string x_axis = "Horizontal";
        string y_axis = "Vertical";
        string boost_button = "p1Boost";
        if (name == "player 2")
        {
            x_axis = "Horizontal 2";
            y_axis = "Vertical 2";
            boost_button = "p2Boost";
        }
        float x_force = Input.GetAxis(x_axis) * 15;
        float y_force = Input.GetAxis(y_axis) * 15;
        rb.AddForce(new Vector2(x_force, y_force)); 
        float xVel = rb.velocity.x;
        float yVel = rb.velocity.y;
        xVel = Mathf.Clamp(xVel, -max_velocity, max_velocity);
        yVel = Mathf.Clamp(yVel, -max_velocity, max_velocity);
        rb.velocity = new Vector2(xVel, yVel);
        
        if (is_boosted && Input.GetButton(boost_button))
        {
            rb.AddForce(rb.velocity.normalized * 10);
            is_boosted = false;

        }
    }
}
//cap speed