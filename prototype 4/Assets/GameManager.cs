using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public string gamestate;
    public int score;
    public GameObject player;
    public GameObject enemy;
    public int level;
    public Text score_text;
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
        
        reset();
    }
    void reset()
    {
        //clean
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        //
        gamestate = "play";
        level = 1;
        score = 0;
        score_text.text = "Score: 0";
        spawnEnemy();
        player.SetActive(true);
    }
    void spawnEnemy()
    {
        float rand_x = Random.value * 8; //8 = arena size - 2
        float rand_y = Random.value * 8;
        //spawns 4 units away from player
        int max_rand = 0;
        while ( Vector2.Distance(new Vector2(rand_x, rand_y),
            player.transform.position)  < 4)
        {
            rand_x = Random.value * 8;
            rand_y = Random.value * 8;
            max_rand++;
            if (max_rand >= 100)
                break;
        }
        GameObject new_enemy = Instantiate(enemy, new Vector3(rand_x, rand_y), Quaternion.identity);
        new_enemy.GetComponent<EnemyControl>().setType("black");
    }
    public void gainScore(int add)
    {
        score += add;
        if(score >= 30)
        {
            int new_level = 1;
            int score_copy = score;
            while(score_copy >= 0)
            {
                if(score_copy >= new_level * 30)
                {
                    score_copy -= new_level * 30;
                    new_level++;
                }else
                {
                    break;
                }
            }
            level = new_level;
        }
        score_text.text = "Score: " + score + "\nLevel: " + level;
    }
    public void gameOver()
    {
        player.SetActive(false);
        gamestate = "gameover";
        score_text.text = "GAME OVER! \n Score = " + score + "\n Press enter to restart.";
    }
    void Update()
    {
        //Debug.Log("update");
        if (Input.GetButton("reset"))
        {
            Debug.Log("reseting");
            reset();
        }

        //spawning enemies;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        int count_black = 0;
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<EnemyControl>().type == "black")
            {
                count_black++;
            }
        }
        for(int i = count_black; i < level; i++)
        {
            spawnEnemy();
        }
    }
            
}


//to do:
//spawn faster when have more points
//enemy switch direction move in higher lv