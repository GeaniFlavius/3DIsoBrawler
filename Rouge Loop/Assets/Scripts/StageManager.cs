using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public GameObject[] enemies;
    private int enemyCount = 0;
    public float transitionTime = 1f;
    public Animator transition;
    public GameObject canvas;
    public Text locationName;

   
    // Start is called before the first frame update
    void Start()
    {

       enemies =  GameObject.FindGameObjectsWithTag("Enemy");
       Debug.Log("ENEMY COUNT : "+ enemies.Length);
       enemyCount =  enemies.Length;


        canvas = GameObject.Find("Crossfade");
        transition = canvas.GetComponent<Animator>();
        locationName = canvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HelpVariables.enemies<=0 && locationName.text != "Nexus") {
            GameObject stageEndScript = GameObject.Find("LevelLoader");
            stageEndScript.GetComponent<StageEnd>().stageEndCanvas(true);
            StartCoroutine(Loadlevel());
        } 
        



    }

    public void stageCleared()
    {
        StartCoroutine(Loadlevel());
    }

    public void stageLose()
    {
        StartCoroutine(LoadNexus());
    }

    IEnumerator LoadNexus()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Nexus 1");
    }
    IEnumerator Loadlevel()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(8f);
        if(SceneManager.GetActiveScene().buildIndex % 2 == 0 && SceneManager.GetActiveScene().buildIndex !=0)
            HelpVariables.time += 40;
        if (SceneManager.GetActiveScene().buildIndex + 1 > 6)
        {
            locationName.text = "";
            SceneManager.LoadScene(0);
        }
        else
        {
            locationName.text = "Nexus";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
