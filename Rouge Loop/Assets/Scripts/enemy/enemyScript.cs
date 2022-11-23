using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public Transform player;
    public float speed = 4f;
    private Rigidbody rb;
    public float minDist = 2f;

    bool up = false;
    bool down = true;
    public bool animate = true;

    // Start is called before the first frame update
    void Start()
    {
        //assign this Objects Rigidbody to this variable
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Enemy Follow script

        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if(dist < minDist)
        {
            for (int i = 0; i < 3; i++)
            {

                //get Attack of specific enemy Attack

            }
        } else
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(player);
        }
        
    }

}
