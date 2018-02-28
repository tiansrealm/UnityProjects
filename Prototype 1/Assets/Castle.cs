using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour {
    public int hp = 5;
    public Text txt_hp;

    void Awake()
    {
        if(name == "white castle")
        {
            txt_hp = GameObject.Find("white castle hp").GetComponent<Text>();
        }
        else if(name == "black castle")
        {
            txt_hp = GameObject.Find("black castle hp").GetComponent<Text>();
        }

        Debug.Log(txt_hp);
        updateText();
    }
    // Update is called once per frame
    void Update () {
    }

    void updateText()
    {
        txt_hp.text = "HP:\n" + hp;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        hp--;
        updateText();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
