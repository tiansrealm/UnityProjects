using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour {
    public float wave_speed;
    public float forceMult;
    // Use this for initialization
    void Start () {
        resetPosition();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x <= 20)
        {
            resetPosition();
        }
        transform.position += new Vector3(-wave_speed, 0);
	}
    void resetPosition()
    {
        transform.position = new Vector3(60, -2);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D other_rb = other.attachedRigidbody;
        if (other.gameObject.tag == "Raft")
        {
            Debug.Log("here");
            Vector2 add_force_position = new Vector2(other_rb.position.x + Random.Range(-2, 2),
                                                       other_rb.position.y );
            Vector2 add_force_force = new Vector2(other_rb.position.x + Random.Range(-100*forceMult, 50*forceMult),
                                                       other_rb.position.y + Random.Range(100*forceMult, 150*forceMult));
            other_rb.AddForceAtPosition(add_force_force, add_force_position);

        }
    }
}
