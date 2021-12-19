using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public float speed;
    public float rot;
    public enum DOGState {Run, Bump, Win, Lose };
    public DOGState st;
    public Animator animator;
    public float ttime;
    public AudioClip[] Audio;
    public AudioSource Source;
    public GameObject dot;
    public int boneCount = 0;
    public GameObject winscreen;
    public GameObject diescreen;

    GameObject dott;
    float amount = 3;
    float amount1 = 3;
    // Start is called before the first frame update
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        amount = Mathf.Clamp(amount, 3, 10);
        amount1 = Mathf.Clamp(amount1, 3, 10);
        rot = transform.rotation.z;
        if (Input.GetKey(KeyCode.D))
        {
            amount1 = 3;
            amount += 0.2f;
            transform.eulerAngles += Vector3.forward * amount;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            amount = 3;
            amount1 += 0.2f;
            transform.eulerAngles -= Vector3.forward * amount1;
        }
        else
        {
            amount = 3;
            amount1 = 3;
        }
        if ((gameObject.transform.rotation.z > 0.68f) || (gameObject.transform.rotation.z < -0.6f))
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }

        switch (st)
        {
            case DOGState.Run:
                transform.Translate(new Vector3(speed * 50 * Time.deltaTime, 0, 0));
                animator.Play("dog run");
                break;

            case DOGState.Bump:
                animator.Play("dog sit");
                ttime += Time.deltaTime;
                if (ttime > 1)
                {
                    st = DOGState.Run;
                }
                break;
            case DOGState.Win:
                speed = 0;
                animator.Play("dog sit");
                winscreen.SetActive(true);
                break;
            case DOGState.Lose:
                speed = 0;
                animator.Play("dog sit");
                diescreen.SetActive(true);
                break;
        }
        if (boneCount >= 6)
        {
            //WIN
            st = DOGState.Win;
        }

        //if (GameObject.Find("playerDot") == null)
        //{
        //    dott = Instantiate(dot);
        //    dott.transform.position = transform.position;
        //}

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Source.PlayOneShot(Audio[0]);
            switch (st)
            {
                case DOGState.Run: st = DOGState.Bump; ttime = 0f; break;
                case DOGState.Bump: break;
            }
        }
        if (collision.gameObject.tag == "bone")
        {
            Destroy(collision.gameObject);
            boneCount++;
        }
        if (collision.gameObject.tag == "dogowner")
        {
            st = DOGState.Lose;
        }
    }
}