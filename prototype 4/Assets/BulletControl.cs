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
        setType("white");
    }
    void Start()
    {
        if(type == "black")
        {
            move_speed = 5f;
        }
        else
        {
            move_speed = 10f;
        }
        rb.velocity = rb.velocity.normalized * move_speed;
    }

    // Update is called once per frame
    void Update () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("collide");
        if ((type == "black"))
        {
            if((col.gameObject.tag == "Player"))
            {
                Destroy(gameObject);
                GameManager.instance.gameOver();
                Debug.Log("Gameover");
            }
            else if(col.gameObject.tag == "enemy")
            {
                EnemyControl enemy_script = col.gameObject.GetComponent<EnemyControl>();
                if (enemy_script.type == "gray")
                {
                    enemy_script.setType("black");
                    enemy_script.last_shot_time = Time.time;
                    Destroy(gameObject);
                }
            }else if(col.gameObject.tag != "bullet")
            {
                Destroy(gameObject);
            }
        }else if (type == "white")
        {
            if(col.gameObject.tag == "enemy")
            {
                if(col.gameObject.GetComponent<EnemyControl>().type == "black")
                {
                    Destroy(col.gameObject);
                    GameManager.instance.gainScore(10);
                }
                Destroy(gameObject);
            }
        }
        if(col.gameObject.tag == "wall" && type == "white")
        {
            Destroy(gameObject);
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
    public void set_direction(Vector2 dir)
    {
        rb.velocity = dir * move_speed;
    }

    public void setType(string new_type)
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
