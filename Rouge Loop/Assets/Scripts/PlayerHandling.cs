using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHandling : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    void Start()
    {
        /*GameObject player = GameObject.Find("Barbarian");
        animator = player.GetComponent<Animator>();*/

        Text text = GetComponentInChildren<Text>();

        /*if (text.text == "Abandoned Woodforest")
        {
            animator.SetTrigger("floorStart");
        }*/

        switch (SceneManager.GetActiveScene().name)
        {
            case "Floor 1":
                text.text = "Abandoned Woodforest";
                //animator.SetTrigger("floorStart");
                break;
            case "Floor 2":
                text.text = "Stronghold Raya";
                //animator.SetTrigger("floorStart");
                break;
            case "Floor 3":
                text.text = "Throne Room Raya";
                //animator.SetTrigger("floorStart");
                break;
        }
    }


    // Update is called once per frame

}
