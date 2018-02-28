using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class arena : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
    //detects when a player has exited arena. Displays gameover
	void OnTriggerExit2D (Collider2D other) {
        Text gamestate_text = GameManager.instance.gamestate_text;
        string gamestate = GameManager.instance.gamestate;
        if(gamestate == "play")
        {
            //Debug.Log(other.name);
            if(other.tag == "Player")
            {
                if (other.name == "player 1")
                {
                    gamestate_text.text = "Knockout!!! \nPlayer 2 Wins!";
                }
                else if (other.name == "player 2")
                {
                    gamestate_text.text = "Knockout!!! \nPlayer 1 Wins!";
                }
                other.gameObject.SetActive(false);
                GameManager.instance.gamestate = "gameover";
            }
            if(other.tag == "points")
            {
                string state = other.GetComponent<pointsControl>().state;
                if (state == "light")
                {
                    GameManager.instance.addPoints("p1", 10);
                }else if(state == "dark")
                {
                    GameManager.instance.addPoints("p2", 10);
                }
                other.GetComponent<pointsControl>().respawn();
            }
        }
    }
}
