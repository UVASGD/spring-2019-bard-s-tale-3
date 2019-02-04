using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_init : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Init Awake method.");
        static_information.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Init Start method.");
        static_information.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
