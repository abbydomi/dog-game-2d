using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public float speed;
    public float rot;
    public enum DOGState {Run, Bump };
    public DOGState st;
    public Animator animator;
    public float ttime; 

    float amount = 3;
    float amount1 = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amount = Mathf.Clamp(amount, 3, 10);
        amount1 = Mathf.Clamp(amount, 3, 10);
        rot = transform.rotation.z;
        if (Input.GetKey(KeyCode.D))
        {
            amount1 = 3;
            amount += 0.1f;
            transform.eulerAngles += Vector3.forward * amount;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            amount = 3;
            amount1 += 0.1f;
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

        switch(st)
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
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            switch(st)
            {
                case DOGState.Run: st = DOGState.Bump; ttime = 0f; break;
                case DOGState.Bump: break;
            }
        }
    }
}