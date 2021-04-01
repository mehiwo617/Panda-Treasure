using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;

    float time = 60.0f;
    int score = 0;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
    }

    void Update()
    {
        /* 時間操作 */
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");

        /*スコア操作*/
        this.scoreText.GetComponent<Text>().text = "Score " + this.score.ToString();
    }


    public void GetTreasure()
    {
        this.score += 50;
    }
}
