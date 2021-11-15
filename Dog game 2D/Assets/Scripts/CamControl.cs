using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject follow;
    [HideInInspector]
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Lerp(x, follow.transform.position.x, 0.1f);
        y = Mathf.Lerp(y, follow.transform.position.y, 0.1f);

        transform.position = (new Vector3(x, y, -10));
    }
}
