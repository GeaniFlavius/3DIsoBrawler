using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool timewardenCanSpecial = false;
    void Start()
    {
        if(HelpVariables.deathCounter >0)
        {
            GameObject.Find("Timewarden").SetActive(true);
        } else
        {
            GameObject.Find("Timewarden").SetActive(false);
        }


        if (HelpVariables.deathCounter > 0)
        {
            GameObject.Find("Wizard").SetActive(true);
            GameObject.Find("Sekiro").SetActive(true);
        }
        else
        {
            GameObject.Find("Wizard").SetActive(false);
            GameObject.Find("Sekiro").SetActive(false);
        }
    }
}
