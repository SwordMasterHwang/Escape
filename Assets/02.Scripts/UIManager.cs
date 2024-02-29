using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text healthtext;//체력
    public Text timer;//타이머
    public GameObject gamepausemenu;//게임 일시정지 메뉴
    private float time;

    void Awake()
    {
        time = 60;
    }
    
    //체력 업데이트
    public void UpdateHealthText(int remainText)
    {
        healthtext.text = "HP "+remainText.ToString();//int형 String으로 변환
        if (remainText == 0)//감염씬
        {
            SceneManager.LoadScene("InfectionEndingScene");
        }
    }
    
    //타이머
    void Timer()
    {
        time -= Time.deltaTime;
        timer.text = string.Format("{0:D2}", (int)time);
        if ((int)time == 0)//핵공격씬
        {
            SceneManager.LoadScene("NuclearEndingScene");
        }

    }
    void Update()
    {
        if(time > 0)
            Timer();
        
        if (Input.GetButtonDown("Cancel"))//정지메뉴 ESC키
        {
            if (gamepausemenu.activeSelf)
            {
                gamepausemenu.SetActive(false);//정지메뉴 가리기
                Time.timeScale = 1;//재시작
            }
            else
            {
                gamepausemenu.SetActive(true);//정지메뉴 보이기
                Time.timeScale = 0;//일시정지
            }
        }
    }
}
