using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float max_velocity;
    private Rigidbody2D rb;
    public GameObject bullet;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //movement
        float xVel = Input.GetAxis("Horizontal")*10;
        float yVel = Input.GetAxis("Vertical")*10;
        xVel = Mathf.Clamp(xVel, -max_velocity, max_velocity);
        yVel = Mathf.Clamp(yVel, -max_velocity, max_velocity);
        rb.velocity = new Vector2(xVel, yVel);

        //fire bullet
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 shoot_dir = Input.mousePosition;
            shoot_dir = Camera.main.ScreenToWorldPoint(shoot_dir);
            shoot_dir -= (Vector2)transform.position;
            GameObject new_bullet = 
                (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            new_bullet.GetComponent<BulletControl>().set_direction(shoot_dir.normalized);
        }

    }
}
