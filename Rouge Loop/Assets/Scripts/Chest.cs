using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject buffcards;
    // Start is called before the first frame update
    void Start()
    {
        buffcards = GameObject.Find("Buffcards");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buffcards.GetComponent<Buffcards>().toggleCanvas();

            Destroy(gameObject);
        }
    }
}
