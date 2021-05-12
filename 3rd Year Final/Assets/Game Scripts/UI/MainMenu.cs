using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject selectPixels;

    public AudioMixer audioMixer;
    public Animator trasition;
    public TMPro.TMP_Dropdown resDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        
        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }

    #region STARTMENU
    public void StartGame()
    {
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        trasition.SetTrigger("Start");

        yield return new WaitForSeconds(.3f);

        LevelLoader.Instance.LoadLevel(levelIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ButtonHover()
    {
        AudioManager.Instance.Play("ButtonHover");
    }

    public void ButtonClicked()
    {
        AudioManager.Instance.Play("ButtonClicked");
    }
    #endregion

    #region SETTINGSMENU

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }   

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    #endregion

}
