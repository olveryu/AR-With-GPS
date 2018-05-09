using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Animator anim;
    private float speed;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetInteger("action", 0);
        speed = 0;
    }

    private void Update()
    {
        if (anim.GetInteger("action") == 1) {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }

    public void idle() {
        anim.SetInteger("action", 0);
        speed = 0;
    }

    public void walk()
    {
        anim.SetInteger("action", 1);
        speed = 0.05f;
    }

    public void fight() {
        anim.SetInteger("action", 2);
        speed = 0;
    }

    public void w()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void a()
    {
        transform.localEulerAngles = new Vector3(0, -90, 0);
    }
    public void s()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    public void d()
    {
        transform.localEulerAngles = new Vector3(0, 90, 0);
    }

}
