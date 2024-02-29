using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalArea : MonoBehaviour
{
    public static bool goal;
    void Start()
    {
        goal = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goal = true;
            SceneManager.LoadScene("EndingScene");//엔딩씬
        }
    }
}
