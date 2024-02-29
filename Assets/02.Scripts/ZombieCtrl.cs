using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieCtrl : MonoBehaviour
{
    public enum ZombieState { idel, trace, attack };//좀비의 상태 정보가 있는 Enumerable

    public ZombieState zombiestate = ZombieState.idel;//좀비의 현 상태 정보를 저장할 Enum
    private Transform ZombieTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    public AudioClip[] attackSound;
    
    public float traceDist = 10.0f; // 추적 사정거리
    public float attackDist = 5.0f; // 공격 사정거리
    
    void Start()
    {
        ZombieTr = this.gameObject.GetComponent<Transform>();
        //좀비 Transform 할당
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //플레이어의 Transform 할당 (플레이어 추적을 위해)
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        //NavMeshAgent 컴포넌트 할당
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckZombieState());
        //일정한 간격으로 몬스터의 행동 상태를 체크하는 코루틴 함수
        StartCoroutine(this.ZombieAction());
        //몬스터의 상태에 따라 동작하는 루틴을 실행하는 코루틴 함수
    }
    
    IEnumerator CheckZombieState()//일정한 간격으로 몬스터의 행동을 체크
    {
        while (true)//좀비가 죽는 것이 아니기 때문에 항상 True로 설정
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(playerTr.position, ZombieTr.position);
            if (dist <= attackDist)//플레이어와 거리가 공격거리보다 작거나 같다면 공격
            {
                zombiestate = ZombieState.attack;
            }
            else if (dist <= traceDist)//플레이어와 거리가 추족거리보다 작거나 같다면 추적
            {
                zombiestate = ZombieState.trace;
            }
            else//그 밖에 상태 아이들 상태
            {
                zombiestate = ZombieState.idel;
            }

        }
    }

    IEnumerator ZombieAction()
    {
        while (true)//좀비가 죽는 것이 아니기 때문에 항상 True로 설정
        {
            switch (zombiestate)
            {
                case ZombieState.idel:
                    nvAgent.Stop();
                    animator.SetBool("IsTrace",false);
                    animator.SetBool("IsAttack",false);
                    break;
                case ZombieState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.Resume();
                    animator.SetBool("IsAttack",false);
                    animator.SetBool("IsTrace",true);
                    break;
                case ZombieState.attack:
                    nvAgent.Stop();
                    animator.SetBool("IsAttack",true);
                    break;
            }

            yield return null;

        }
    }
    //좀비 사운드
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(attackSound[UnityEngine.Random.Range(0, attackSound.Length)],transform.position);//랜덤적으로 사운드 다르게 설정
    }

    void OnPlayerDie()
    {
        StopAllCoroutines();//좀비의 상태를 체크하는 코루틴 모두 정지
        animator.SetBool("IsTrace",false);
        nvAgent.Stop();
        //좀비 추적 정지
    }
    
}
