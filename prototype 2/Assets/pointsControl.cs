using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsControl : MonoBehaviour {
    public string state = "none";
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("point collide");
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.name == "player 1"){
                GetComponent<SpriteRenderer > ().color = new Color(0.9f, 0.9f, 0.9f, 1); //light gray
                state = "light";
            }else
            {
                GetComponent < SpriteRenderer > ().color = new Color(0.5f, 0.5f, 0.5f, 1); //dark gray
                state = "dark";
            }
        }
    }
    public void respawn()
    {
        transform.position = Random.insideUnitCircle * 11;
        resetAttributes();
    }
    public void resetAttributes()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        state = "none";
        GetComponent<SpriteRenderer>().color = new Color(0, 1, 55 / 255, 1);
    }
}
