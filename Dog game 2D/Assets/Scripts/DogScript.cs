using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public bool running;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.forward * 3;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= Vector3.forward * 3;
        }
        if (running)
        {
            transform.Translate(new Vector3(speed, 0, 0));
        }
    }
}
