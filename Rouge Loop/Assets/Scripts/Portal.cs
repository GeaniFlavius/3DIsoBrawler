using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public string scene;
    public float transitionTime = 1f;
    public Animator transition;
    public Text locationName;

    string portalSoundPath = "event:/SFX/Global/Portal Sound";

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot(portalSoundPath, GetComponent<Transform>().position);


            if (gameObject.tag == "KillPlane")
            {
                HelpVariables.deathCounter += 1;
                HelpVariables.time = 120.0f;
            }
         /* SceneManager.LoadScene(scene);
          HelpVariables.time = 50;*/

            LoadNextLevel();

        }

    }

    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        switch (scene) {
            case "Nexus 1" : locationName.text  = "Nexus";
            break;
            case "Floor 1" : locationName.text = "Abandoned Woodforest";
            break;
            default:  locationName.text = "Unknown";
            break;
        }
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
