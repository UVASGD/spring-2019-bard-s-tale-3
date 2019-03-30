using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        col.gameObject.transform.position = spawn.transform.position;
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = cameraPoint.transform.position;
        static_information.room_index = static_information.which_room_am_I_in(spawn.transform.position.x, spawn.transform.position.y);
    }
}
