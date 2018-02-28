using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public string gamestate;
    public GameObject player;
    private float enemy_last_spawn_time;
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
    void Start()
    {
        reset();
    }

    void reset()
    {
        gamestate = "play";
    }

    void Update()
    {
        //Debug.Log("update");
        if (Input.GetButton("reset"))
        {
            Debug.Log("reseting");
            reset();
        }
    }
            
}


//to do:
//spawn enemys randomly in certain distance away from player
//enemy shoots 3 bullet in cone at player
//enemy bullet contaminates gray one to become black
//scoring: get points for kill black one
//spawn faster when have more points