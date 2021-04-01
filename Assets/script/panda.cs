using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class panda : MonoBehaviour
{

    private float jumpPower = 150f;
    private Animator anim;
    private Rigidbody rigid;
    GameObject director;

    /* 宝物見つけたときの効果音よう */
    public AudioClip treasureSE;
    AudioSource aud;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walking", false);
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(0.0f, 0.0f, -0.05f);
            anim.SetBool("walking", true);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.0f, 0.0f, 0.05f);
            anim.SetBool("walking", true);
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(-0.05f, 0.0f, 0.0f);
            anim.SetBool("walking", true);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.05f, 0.0f, 0.0f);
            anim.SetBool("walking", true);
        }

        // 右回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0.0f, 0.5f, 0.0f);
        }

        // 左回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0.0f, -0.5f, 0.0f);
        }


        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(transform.up * this.jumpPower);
        }
    }

    /* 衝突操作 */
    private void OnTriggerEnter(Collider collider)
    {
        /* 衝突したのが宝物だった場合のみ */
        if (collider.CompareTag("Treasure"))
        {
            this.aud.PlayOneShot(this.treasureSE);
            this.director.GetComponent<GameDirector>().GetTreasure();
            Debug.Log("Catch!!!!");
            Destroy(collider.gameObject);
        }
    }
}
