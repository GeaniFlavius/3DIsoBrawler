using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuController : MonoBehaviour
{

    [Header("Levels to Load")] public string newGameLevel;
    private string levelToLoad;
    public TMP_Text volumeTextValue;
    public Slider volumeSlider;
    public GameObject comfirmationPrompt;

    public void StartGame()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void SetVolume(float volume)
    {
        //TODO Testing If it works. Needs Audio Implamentation
        AudioListener.volume = volume;
        //volumeTextValue.text = volume.ToString("0.0");
        print(volume);
    }

    public void VolumeApply()
    {
        //TODO FMOD?
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPrompt.SetActive(false);
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
