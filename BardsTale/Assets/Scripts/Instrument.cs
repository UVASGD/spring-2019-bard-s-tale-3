using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{

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
}
