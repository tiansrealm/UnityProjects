using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Vector2Extension
{
    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
}
public class EnemyControl : MonoBehaviour {
    public string type;
    public float movespeed;
    private float last_time_changed_direction;
    //private float spawn_time;
    public float last_shot_time;
    Rigidbody2D rb;
    public GameObject bullet;
    // Use this for initialization
    void Awake () {
        setType("gray");
        last_time_changed_direction = 0;
        rb = GetComponent<Rigidbody2D>();
        last_shot_time = Time.time;
    }
	
    public void setType(string new_type)
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
        float change_speed = GameManager.instance.level / 5;
        if(change_speed > 1) { change_speed = 1;  }
        if (time_diff >= 2 - change_speed)
        {
            ///new direction
            rb.velocity = Random.insideUnitCircle.normalized * movespeed;
            last_time_changed_direction = Time.time;
        }
        if(type == "black")
        {
            if(Time.time - last_shot_time >= 5)
            {
                shoot();
                last_shot_time = Time.time;
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
        Vector2 shoot_dir = GameManager.instance.player.transform.position;
        shoot_dir -= (Vector2)transform.position;
        GameObject new_bullet =
            (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        new_bullet.GetComponent<BulletControl>().set_direction(shoot_dir.normalized);
        new_bullet.GetComponent<BulletControl>().setType("black");

        Vector2 shoot_dir_rotated_up = shoot_dir.Rotate(15f);
        GameObject new_bullet2 =
            (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        new_bullet2.GetComponent<BulletControl>().set_direction(shoot_dir_rotated_up.normalized);
        new_bullet2.GetComponent<BulletControl>().setType("black");

        Vector2 shoot_dir_rotated_down = shoot_dir.Rotate(-15f);
        GameObject new_bullet3 =
            (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        new_bullet3.GetComponent<BulletControl>().set_direction(shoot_dir_rotated_down.normalized);
        new_bullet3.GetComponent<BulletControl>().setType("black");
    }
}

