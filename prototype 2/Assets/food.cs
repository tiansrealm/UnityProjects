using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {
    private float mass_gain = 0.2F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            //player eats food->empower player
            other.attachedRigidbody.mass += mass_gain;
            other.transform.localScale += new Vector3(mass_gain / 2, mass_gain / 2, 0);

            //food relocates
            transform.position = Random.insideUnitCircle * 9; //arena size = 10
        }
	}
}
