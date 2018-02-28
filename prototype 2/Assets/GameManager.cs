using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public Text gamestate_text;
    public Text score;
    public Text timer;
    public string gamestate;
    public GameObject p1;
    public GameObject p2;
    public GameObject food;
    public GameObject points1;
    public GameObject points2;
    public GameObject points3;
    public GameObject points4;
    public GameObject points5;
    public GameObject points6;

    int p1_points = 0;
    int p2_points = 0;
    float time_left = 0;
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        gamestate = "play";
    }
    // Use this for initialization
    void Start () {
        reset();
	}
	
	void reset () {
        time_left = 60;
        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(true);
        Rigidbody2D rb1 = p1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = p2.GetComponent<Rigidbody2D>();
        p1.GetComponent<playerControl>().is_boosted = false;
        p2.GetComponent<playerControl>().is_boosted = false;
        rb1.mass = 1;
        rb2.mass = 1;
        rb1.transform.localScale = new Vector3(1,1,0);
        rb2.transform.localScale = new Vector3(1, 1, 0);
        rb1.transform.localPosition = new Vector3(0, -7, 0);
        rb2.transform.localPosition = new Vector3(0, 7, 0);
        rb1.velocity = new Vector2(0, 0);
        rb2.velocity = new Vector2(0, 0);
        p1_points = 0;
        p2_points = 0;
        food.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        points1.GetComponent<Transform>().localPosition = new Vector3(-7, 7, 0);
        points2.GetComponent<Transform>().localPosition = new Vector3(7, 7, 0);
        points3.GetComponent<Transform>().localPosition = new Vector3(-9, 0, 0);
        points4.GetComponent<Transform>().localPosition = new Vector3(9, 0, 0);
        points5.GetComponent<Transform>().localPosition = new Vector3(-7, -7, 0);
        points6.GetComponent<Transform>().localPosition = new Vector3(7, -7, 0);
        points1.GetComponent<pointsControl>().resetAttributes();
        points2.GetComponent<pointsControl>().resetAttributes();
        points3.GetComponent<pointsControl>().resetAttributes();
        points4.GetComponent<pointsControl>().resetAttributes();
        points5.GetComponent<pointsControl>().resetAttributes();
        points6.GetComponent<pointsControl>().resetAttributes();
        gamestate = "play";
        gamestate_text.text = "Start!";
        p1_points = 0;
        p2_points = 0;
        score.text = "Score:\nPlayer 1: " + p1_points + "\nPlayer 2: " + p2_points;
    }

    public void addPoints(string player, int points)
    {
        if(player == "p1")
        {
            p1_points += points;
        }else if(player == "p2")
        {
            p2_points += points;
        }
        score.text = "Score:\nPlayer 1: " + p1_points + "\nPlayer 2: " + p2_points; 
    }
    void Update()
    {
        //Debug.Log("update");
        if (Input.GetButton("reset"))
        {
            Debug.Log("reseting");
            reset();
        }
        if (time_left >= 0)
            time_left -= Time.deltaTime;
        if (time_left < 0)
        {
            GameOver();
        }
        timer.text = "Time Left:\n" + (int)time_left;
    }
    void GameOver()
    {
        if (gamestate == "play")
        {
            string winner = "Player 1 Wins!";
            if (p2_points > p1_points)
            {
                winner = "Player 2 wins!";
            }else if(p2_points == p1_points)
            {
                winner = "It's a Draw!";
            }
            gamestate_text.text = "Time Over!\n " + winner + "\nPress 'p' \nto restart.";
            
            gamestate = "gameover";
        }
    }
}
