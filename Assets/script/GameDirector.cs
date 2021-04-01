using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject scoreText;
    GameObject countText;
    GameObject panda;

    float time = 60.0f;
    float count = 4.0f;
    private int countdown;
    private int score = 0;

    bool canstart = false;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
        this.countText = GameObject.Find("Count");
        this.panda = GameObject.Find("pandakko");
    }

    void Update()
    {
        /* 最初のカウントダウン */
        if(count >= 1)
        {
            this.count -= Time.deltaTime;
            countdown = (int)this.count;
            this.countText.GetComponent<Text>().text = this.countdown.ToString();
        }

        /* ゲームスタート */
        if (count <= 1)
        {
            /* pandaの操作無効化 */
            if (!canstart)
            {
                this.panda.GetComponent<panda>().canstart = true;
                this.canstart = true;
                this.countText.SetActive(false);
            }

            /* 時間操作 */
            this.time -= Time.deltaTime;
            this.timerText.GetComponent<Text>().text = this.time.ToString("F1");

            /*スコア操作*/
            this.scoreText.GetComponent<Text>().text = "Score " + this.score.ToString();
        }
    }

    /* 通常色宝物 */
    public void GetTreasure()
    {
        this.score += 50;
    }

    /* レア色宝物 */
    public void GetRare()
    {
        this.score += 250;
    }
}
