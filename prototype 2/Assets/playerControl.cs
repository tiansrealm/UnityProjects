using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public float max_velocity;
    private Rigidbody2D rb;
    public bool is_boosted = false;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        string x_axis = "Horizontal";
        string y_axis = "Vertical";
        string boost_button = "p1Boost";
        if (name == "player 2")
        {
            x_axis = "Horizontal 2";
            y_axis = "Vertical 2";
            boost_button = "p2Boost";
        }
        float x_force = Input.GetAxis(x_axis) * 25;
        float y_force = Input.GetAxis(y_axis) * 25;
        if ( (x_force > 0 && rb.velocity.x < max_velocity / 3) || 
                (x_force < 0 && rb.velocity.x > -max_velocity / 3)  )
        {
            rb.AddForce(new Vector2(x_force, 0));
        }
        if ((y_force > 0 && rb.velocity.y < max_velocity / 2) ||
                (y_force < 0 && rb.velocity.y > -max_velocity / 2))
        {
            rb.AddForce(new Vector2(0, y_force));
        }
        float xVel = rb.velocity.x;
        float yVel = rb.velocity.y;
        xVel = Mathf.Clamp(xVel, -max_velocity, max_velocity);
        yVel = Mathf.Clamp(yVel, -max_velocity, max_velocity);
        rb.velocity = new Vector2(xVel, yVel);

        if (is_boosted && Input.GetButton(boost_button))
        {
            Debug.Log("using boost");
            Vector2 direction = new Vector2(Input.GetAxis(x_axis), Input.GetAxis(y_axis));
            rb.AddForce(direction.normalized * 1000);
            rb.mass = 1;
            rb.transform.localScale = new Vector3(1, 1, 0);
            is_boosted = false;

        }
    }
}
