using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageEnd : MonoBehaviour
{
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void stageEndCanvas(bool win)
    {
        GameObject stageEnd = GameObject.Find("StageEnd");
        Animator stageEndAnimator = stageEnd.GetComponent<Animator>();
        Text[] texts;
        texts = stageEnd.GetComponentsInChildren<Text>();

        switch (win)
        {
            case false:
                texts[0].text = "YOU DIED";
                texts[0].color = Color.red;
                texts[1].text = "";
                
                break;

            case true:
                texts[0].text = "Stage Cleared";
                texts[0].color = Color.cyan;
                texts[1].text = "40s Reward";
                texts[1].color = Color.cyan;
                break;
        }
        stageEndAnimator.SetTrigger("stageEnd");
    }
}
