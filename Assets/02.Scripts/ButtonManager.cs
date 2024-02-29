using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //게임 인트로씬
    public void GameIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }
    
    //게임 재시작
    public void GameRestart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;//재시작
    }

    //게임 종료
    public void ExitGame()
    {
        Application.Quit();
    }

}
