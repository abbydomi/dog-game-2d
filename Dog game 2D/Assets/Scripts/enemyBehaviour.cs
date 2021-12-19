using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public GameObject Dot;
    public GameObject Player;
    
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = Player.GetComponent<SpriteRenderer>().flipY;

        x = Mathf.Lerp(x, Dot.transform.position.x, 0.1f);
        y = Mathf.Lerp(y, Dot.transform.position.y, 0.1f);

        transform.position = (new Vector3(x, y, -0.1f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dot")
        {
            Debug.Log("Collided");
           Dot.transform.position = Player.transform.position;
        }
    }
}
