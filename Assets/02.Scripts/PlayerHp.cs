using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int hp = 0;//플레이어 체력

    //플레이어 시작 체력
    private void Start()
    {
        hp = 100;
    }

    //플레이어 체력 감소
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            hp -= 10;

            if (hp < 0)
            {
                hp = 0;
                PlayerDie();
            }
            
            GameObject.Find("UIManager").GetComponent<UIManager>().UpdateHealthText(hp);
            //UIManager GameObject의 UIManager 스크립트 UpdateHealthText 함수 호출
        }
    }

    void PlayerDie()
    {
        //좀비 태그의 모든 게임오브젝트 가져옴
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in zombies)
        {
            zombie.SendMessage("OnPlayerDie",SendMessageOptions.DontRequireReceiver);
            //해당 함수가 없더라도 함수가 없다는 메시지를 리턴받지 않겠다는 옵션
        }
    }
}
