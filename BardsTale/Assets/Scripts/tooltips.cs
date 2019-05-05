using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tooltips : MonoBehaviour {

    private string[] tooltip_strings = new string[] {
        "Press B to see a list of spells!",
        "Cast fireball to exit the room!",
        "Kill all the enemies in a room to leave!",
        "Be sure to keep the room lit!",
        "Kill the boss to exit the room!",
        "Touch the purple tile to finish the game!"
    };

    private Text myText;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = tooltip_strings[static_information.room_index];
	}
}
