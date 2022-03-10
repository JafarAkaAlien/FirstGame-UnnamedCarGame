using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    AudioSource audioS;
    public float audiopitch;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.pitch = audiopitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
