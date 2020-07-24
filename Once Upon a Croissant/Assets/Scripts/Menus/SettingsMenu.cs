using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    //difficulties
    public GameObject prefabManager;
    public GameObject OptionsMenu;
    public GameObject canvas;
    private PrefabManager difficulty;



    void Start() 
    {
        difficulty = prefabManager.GetComponent<PrefabManager>();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currenResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                currenResolutionIndex = i;
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currenResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen) {
        Screen.fullScreen = isFullscreen; 
    }

    public void SetResolution (int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void setEasy() {
        difficulty.SetEasyMidGame();
        OptionsMenu.SetActive(false);
        canvas.GetComponent<GameOverMenu>().respawn();
        canvas.GetComponent<PauseMenu>().Resume();

    }

    public void setNormal() {
        difficulty.SetNormalMidGame();
        OptionsMenu.SetActive(false);
        canvas.GetComponent<GameOverMenu>().respawn();
        canvas.GetComponent<PauseMenu>().Resume();
    }

    public void setHard() {
        difficulty.SetHardMidGame();
        OptionsMenu.SetActive(false);
        canvas.GetComponent<GameOverMenu>().respawn();
        canvas.GetComponent<PauseMenu>().Resume();

    }
    

}
