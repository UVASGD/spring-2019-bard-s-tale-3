using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I'm sorry, but it's probably for the best that speedrunning the game takes more than just going to every door. 
// I've gone a little janky here, but yer gonna have to clear the room to use the doors in it.
// Also, if the door you're trying to enter is the door out of the second room, you need to have cast fireball once.
public class LilFuckinDoorScript : MonoBehaviour
{

    public GameObject spawn;
    public GameObject cameraPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // to leave, the room must be clear
        if (static_information.is_the_current_room_clear())
        {
            // can't leave room 2 until fireball has been cast
            if (spawn.name.Equals("Room3Enter") && static_information.has_casted_fireball == false)
            { return; }

            // move room implementation
            col.gameObject.transform.position = spawn.transform.position;
            GameObject camera = GameObject.Find("Main Camera");
            camera.transform.position = cameraPoint.transform.position;
            static_information.room_index = static_information.which_room_am_I_in(spawn.transform.position.x, spawn.transform.position.y);
        }
    }
}
