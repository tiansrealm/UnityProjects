using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    //public float max_velocity;
    [Range(1, 10)]
    public float jumpVelocity;
     
    private Rigidbody2D rb;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        string x_axis = "Horizontal";
        // string y_axis = "Vertical";

        rb.velocity = new Vector2(Input.GetAxis(x_axis)*5, rb.velocity.y);
        //Debug.Log(rb.velocity.y);
        if(Input.GetButton("Jump") && rb.velocity.y < 0.5)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }
}


//talk about design/prototype goals
//heuristics abd # of players. 
//my story fits 1 player, easy to test wave mechanic. can expand to 2 players. 
//escaping away out to sea