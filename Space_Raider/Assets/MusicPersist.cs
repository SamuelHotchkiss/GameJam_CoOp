using UnityEngine;
using System.Collections;

public class MusicPersist : MonoBehaviour 
{
    public static MusicPersist music;	// allow singleton
    void Start()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(music);
        }
        else if (music != this)
            DestroyImmediate(gameObject);
    }
    void OnLevelWasLoaded(int level)
    {
        if (level >= 2)
            DestroyImmediate(gameObject);
        else if (!GetComponentInParent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
    }
}
