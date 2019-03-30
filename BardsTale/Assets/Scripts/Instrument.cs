using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{

    public string bardSpritePath = "";
    public static GameObject currentInstrument;

    Dictionary<string, Song> songIndex = new Dictionary<string, Song>();

    // Start is called before the first frame update
    void Start()
    {

        Song[] songs = GetComponents<Song>();
        for(int i = 0; i < songs.Length; i++)
        {
            Debug.Log(songs[i].songName);
            songIndex.Add(songs[i].songName, songs[i]);
        }
        /*
        for(int i = 0; i < songNames.Length; i++)
        {
            Component c = GetComponent(System.Type.GetType(songNames[i]));
            Song s = (Song)c;
            songIndex.Add(songNames[i], s);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string songName)
    {
        songIndex[songName].Play();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Hero")
        {
            GameObject bard = col.gameObject;
            bard.GetComponent<PlaySong>().currentInstrument = this;
            bard.GetComponent<bard_animation_script>().SetInstrument(bardSpritePath);

            if(currentInstrument != null)
            {
                currentInstrument.GetComponent<SpriteRenderer>().enabled = true;
                currentInstrument.transform.parent = GameObject.Find("Overworld").transform;
            }
            currentInstrument = gameObject;

            GetComponent<SpriteRenderer>().enabled = false;
            this.transform.parent = bard.transform;

            GameObject ih = GameObject.Find("INPUT_HANDLER");
            ih.GetComponent<SpellCasting>().audio = gameObject.GetComponent<AudioSource>();
        }
    }
}
