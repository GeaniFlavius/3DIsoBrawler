using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeHandling : MonoBehaviour
{
    public TMP_Text enemycounter;
    public float timeLossPerSecond = 1.0f;
    public TMP_Text timer;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        HelpVariables.enemies = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        enemycounter.SetText("" + HelpVariables.enemies);
    }

    // Update is called once per frame
    void Update()
    {
        enemycounter.SetText("" + HelpVariables.enemies);
        if (HelpVariables.time>0){
            HelpVariables.time -= Time.deltaTime*timeLossPerSecond;
            HelpVariables.doneNothing +=  Time.deltaTime;
            timer.SetText(""+ System.Math.Round(HelpVariables.time,0));
            }
       else if(HelpVariables.time<=0)
            playerDies();
    }


    void playerDies(){

        //Destroy(player);
        HelpVariables.deathCounter +=1;
        print(HelpVariables.deathCounter);

        GameObject stageEndScript = GameObject.Find("LevelLoader");
        stageEndScript.GetComponent<StageEnd>().stageEndCanvas(false);
        //SceneManager.LoadScene("Nexus 1");
        stageEndScript.GetComponent<StageManager>().stageLose();
        HelpVariables.time = 120.0f;
        HelpVariables.doneNothing = 0;

        
    }
    public void playerGetsHit(float damage){
        HelpVariables.doneNothing = 0;
        if(HelpVariables.isInvincible==false)
            HelpVariables.time -= damage;
        else print("Doged!");
    }
    public void playerGainsTime(float gain){
        HelpVariables.time += gain;
    }

    public void increaseTimeLossPerSecond(float increase,float duration){
        while(duration>0){
            timeLossPerSecond = increase;
        }
        if(duration<=0)
            timeLossPerSecond = 1.0f;
    }

    public void decreaseTimeLossPerSecond(float percentage)
    {
        timeLossPerSecond -= (0.01f*percentage);
        Debug.Log(percentage +"  "  + 0.01f*percentage);
    }
}
