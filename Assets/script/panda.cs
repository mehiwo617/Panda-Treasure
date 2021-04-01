using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class panda : MonoBehaviour
{

    private float jumpPower = 150f;
    private Animator anim;
    private Rigidbody rigid;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walking", false);
        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(0.0f, 0.0f, -0.1f);
            anim.SetBool("walking", true);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.0f, 0.0f, 0.1f);
            anim.SetBool("walking", true);
        }
        // 前に移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
            anim.SetBool("walking", true);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
            anim.SetBool("walking", true);
        }

        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(transform.up * this.jumpPower);
        }
    }
}
