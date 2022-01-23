using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public List<AudioClip> clips;

    private int currentClip = 0;
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = clips[currentClip];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_source.isPlaying)
        {
            currentClip = (currentClip + 1) % 3;
            _source.clip = clips[currentClip];
            _source.Play();
        }
    }
}
