using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public bool running;
    public float speed;
    public float rot;
    public enum DOGState {Run, Bump };
    public DOGState st;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot = transform.rotation.z;
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.forward * 3;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= Vector3.forward * 3;
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
                transform.Translate(new Vector3(speed*50*Time.deltaTime, 0, 0));
                break;

            case DOGState.Bump:
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hello?");
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("YEOUCH");
            st = DOGState.Bump;
        }
    }
}
