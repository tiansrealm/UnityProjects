using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<playerControl>().is_boosted == false)
            {
                other.gameObject.GetComponent<playerControl>().is_boosted = true;
                //player eats food->empower player
                float mass_gain = 0.2f;
                other.attachedRigidbody.mass += mass_gain;
                other.transform.localScale += new Vector3(mass_gain*2, mass_gain*2, 0);
            
            }
            //food relocates
            transform.position = Random.insideUnitCircle * 11; //arena size = 12.5
        }
    }
}
    