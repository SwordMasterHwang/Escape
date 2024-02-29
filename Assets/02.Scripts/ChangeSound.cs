using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSound : MonoBehaviour
{
    public AudioClip scenechangesound;
    private AudioSource scenechangeaudio;
    void Awake()
    {
        //오디오 소스 연결
        scenechangeaudio = this.gameObject.GetComponent<AudioSource>();
    }
    
    void Start()
    {
        //오디오 소스 한번 플레이
        scenechangeaudio.PlayOneShot(scenechangesound);
    }
}
