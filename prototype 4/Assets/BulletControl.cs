using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    public string type;
    public GameObject enemy;
    public float move_speed;
    private Rigidbody2D rb;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start () {
        set_type("white");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("collide");
        if ((type == "black") && (col.gameObject.tag == "Player"))
        {
            Debug.Log("hit player");
        }else if ((type == "white") && (col.gameObject.tag == "enemy"))
        {
            Destroy(col.gameObject);
            Debug.Log("hit enemy");
        }
        if(col.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Debug.Log("hit wall");
        }
    }
    public void set_direction(Vector2 dir)
    {
        rb.velocity = dir * move_speed;
    }

    public void set_type(string new_type)
    {
        SpriteRenderer my_sprite = GetComponent<SpriteRenderer>();
        if (new_type == "white")
        {
            type = "white";
            my_sprite.color = Color.white;
        }
        else if (new_type == "black")
        {
            type = "black";
            my_sprite.color = Color.black;
        }
    }
}
