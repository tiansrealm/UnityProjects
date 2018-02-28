using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("collide");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("player");
        }
    }
}
