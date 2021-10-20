using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets current;

    // Assets
    public List<AudioClip> shootAudioClips = new List<AudioClip>();
    public List<AudioClip> hitAudioClips = new List<AudioClip>();
    public List<AudioClip> voiceLineClips = new List<AudioClip>();
    public List<AudioClip> enemyDeathClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        current = this;

    }
}
