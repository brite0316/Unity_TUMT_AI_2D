using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string foxName = "狐狸";
    public bool pass = false;

    private Rigidbody2D r2d;
    private Transform tra;


    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) tra.eulerAngles = new Vector3(0, 0, 0);
        if(Input.GetKeyDown(KeyCode.A)) tra.eulerAngles = new Vector3(0, 180, 0);
    }
    //Debug.Log(Input.GetAxis("Horizontal"));
    //r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    private void FixedUpdate()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));

    }

}

