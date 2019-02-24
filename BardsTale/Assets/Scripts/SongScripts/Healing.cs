using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : Song
{
    public int healBy = 1;

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
        static_information.hero.GetComponentInChildren<self_spellcast_animation>().castSpell("heal");
        static_information.hero.GetComponent<hero_act>().healDamage(healBy);
    }
}
