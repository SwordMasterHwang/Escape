using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
   
    public AudioClip[] hitSound;

    //플레이어 사운드
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            AudioSource.PlayClipAtPoint(hitSound[UnityEngine.Random.Range(0, hitSound.Length)],transform.position);//랜덤적으로 사운드 다르게 설정
        }
    }
}
