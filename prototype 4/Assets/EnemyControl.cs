using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public string type;
    public float movespeed;
    private float last_time_changed_direction;
    //private float spawn_time;
    private float last_shot_time;
    Rigidbody2D rb;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        set_type("gray");
        last_time_changed_direction = 0;
        rb = GetComponent<Rigidbody2D>();
        last_shot_time = Time.time;
    }
	
    void set_type(string new_type)
    {
        SpriteRenderer my_sprite = GetComponent<SpriteRenderer>();
        if(new_type == "gray")
        {
            type = "gray";
            my_sprite.color = Color.gray;
        }else if(new_type == "black")
        {
            type = "black";
            my_sprite.color = Color.black;
        }
    }
	// Update is called once per frame
	void Update () {
        //random movement
        float time_diff = Time.time - last_time_changed_direction;
        if (time_diff >= 1)
        {
            ///new direction
            rb.velocity = Random.insideUnitCircle.normalized * movespeed;
            last_time_changed_direction = Time.time;
        }
        if(type == "black")
        {
            if(Time.time - last_shot_time >= 1)
            {
                shoot();
            }
        }
       /* if(type == "gray")
        {
            if(Time.time - spawn_time >= 5)
            {
                set_type("black");
            }
        }*/
    }

    void shoot()
    {
        Vector2 shoot_dir = Input.mousePosition;
        shoot_dir = Camera.main.ScreenToWorldPoint(shoot_dir);
        shoot_dir -= (Vector2)transform.position;
        GameObject new_bullet =
            (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        new_bullet.GetComponent<BulletControl>().set_direction(shoot_dir.normalized);
        new_bullet.GetComponent<BulletControl>().set_type("black");
    }
}

