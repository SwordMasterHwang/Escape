using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public Transform[] points; //좀비 출현할 위치를 담을 배열
    public GameObject zombieprefab; // 좀비 프리팹 할당

    public float spawntime = 1.0f; //좀비 스폰 시간
    public int maxzombie = 20; //좀비 최대 스폰 수
    void Start()
    {
        //좀비 스폰 위치를 찾아 하위에 있는 모든 위치들을 할당 
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        if (points.Length > 0)
        {
            //좀비 생성 코루틴 함수 호출
            StartCoroutine(this.Spawnzombie());
        }
    }

    //몬스터 생성 코루틴함수
    IEnumerator Spawnzombie()
    {
        while (true)
        {  
            int zombiecount = GameObject.FindGameObjectsWithTag("Zombie").Length;//현재 생성된 좀비 수
            if (zombiecount < maxzombie)//최대 좀비 수 보다 적으면 좀비 생성
            {
                yield return new WaitForSeconds(spawntime);//설정한 시간만큼 생성 대기

                int random = UnityEngine.Random.Range(1, points.Length);//위치 랜덤

                Instantiate(zombieprefab, points[random].position, points[random].rotation);//동적 생성
            }
            else
            {
                yield return null;
            }
        }
    }
    
}
