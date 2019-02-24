using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Song
{

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Play()
    {

        static_information.has_casted_fireball = true;
        for (int j = 0; j < static_information.fireballs.Length; j++)
        {
            if (static_information.fireballs[j].GetComponent<SpriteRenderer>().enabled == false)
            {
                static_information.fireballs[j].transform.position = static_information.hero.transform.position;
                static_information.fireballs[j].GetComponent<fireball_animation>().castFireball();
                break;
            }
        }
        static_information.hero.GetComponentInChildren<self_spellcast_animation>().castSpell("fireball");

    }
}
