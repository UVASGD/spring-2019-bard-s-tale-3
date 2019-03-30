using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilFuckinDoorScript : MonoBehaviour
{

    public float teleportX = 0;
    public float teleportY = 0;
    public float roomX = 0;
    public float roomY = 0;

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
        col.gameObject.transform.position = new Vector3(teleportX, teleportY, 0.0f);
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(roomX, roomY, -10.0f);
    }
}
