using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float forceApplied = 300;
    public float max_paddleSpeed = 10f;
    //private Vector2 playerPos;
    private Rigidbody2D rb;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        //playerPos = rb.position;
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(Input.GetAxis("Horizontal"));
        string move_axis = "Horizontal";
        if(name == "paddle 2")
        {
            move_axis = "Horizontal 2";
        }
        float xPos = rb.position.x + Input.GetAxis(move_axis) /2;
        xPos = Mathf.Clamp(xPos, -6, 6);
        rb.position = new Vector2(xPos, rb.position.y);

    }

    void OnCollisionEnter2D(Collision2D col){
        Rigidbody2D otherRb = col.gameObject.GetComponent<Rigidbody2D>();

        if(otherRb.velocity.magnitude == 0)
        { //initial push
            otherRb.AddForce(new Vector2(forceApplied, forceApplied));
        }
        //add extra force on top of the bounce
        //Vector2 forceVec = otherRb.velocity.normalized * -1 * forceApplied;
        //otherRb.AddForce(forceVec);
        
    }
}
//to do
/*
 cap the min maxspeed //done
  add drag , remove gravity //done
  add castles//

  trigger event for castle minus health
  //add change color
 */
