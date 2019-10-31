using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string foxName = "狐狸";
    public bool pass = false;
    public bool isGround = false;

    private Rigidbody2D r2d;
    private Transform tra;


    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }
    //Debug.Log(Input.GetAxis("Horizontal"));
    //r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    private void FixedUpdate()
    {
        walk(); //呼叫方法
        Jump(); //呼叫方法
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
         Debug.Log("碰到東西" + collision.gameObject); 
    }

    /// <summary>
    /// 走路
    ///  </summary>
    private void walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
    
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
            
    }

    //參數語法 ; 類型 名稱
    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向 , 左轉為 180, 右轉為 0</param>
    private void Turn(int direction)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
}

