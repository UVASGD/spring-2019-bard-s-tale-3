using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{

    public static PlaySong playSong; //singleton

    Stack<char> noteHistory = new Stack<char>();
    public string[] songNames;
    public string[] songNotes;
    public Dictionary<string, string> invertedSongIndex = new Dictionary<string, string>();
    int longestSongLength = 0;
    public Instrument currentInstrument;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < songNames.Length && i < songNotes.Length; i++)
        {
            invertedSongIndex.Add(songNotes[i], songNames[i]);
            if(songNotes[i].Length > longestSongLength)
            {
                longestSongLength = songNotes[i].Length;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!static_information.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.J))
                noteHistory.Push('j');
            if (Input.GetKeyDown(KeyCode.K))
                noteHistory.Push('k');
            if (Input.GetKeyDown(KeyCode.L))
                noteHistory.Push('l');
            if (Input.GetKeyDown(KeyCode.Semicolon))
                noteHistory.Push(';');
            if (Input.GetKeyDown(KeyCode.Space))
                Play();
        }

    }

    void Play()
    {
        string potentialSong = "";
        string confirmedSong = "";

        while (noteHistory.Count > 0 && potentialSong.Length <= longestSongLength)
        {
            potentialSong = noteHistory.Pop() + potentialSong;

            if (invertedSongIndex.ContainsKey(potentialSong))
            {
                confirmedSong = invertedSongIndex[potentialSong];
            }

        }

        if (confirmedSong != "")
        {
            currentInstrument.Play(confirmedSong);
        }
    }

}
