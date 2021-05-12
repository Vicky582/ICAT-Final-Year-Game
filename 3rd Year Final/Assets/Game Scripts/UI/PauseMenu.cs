using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Restart()
    {
        LevelLoader.Instance.LoadLevel(1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        LoadNextLevel(0);
    }

    void LoadNextLevel(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(.3f);

        LevelLoader.Instance.LoadLevel(levelIndex);
    }

    public void ButtonHover()
    {
        AudioManager.Instance.Play("ButtonHover");
    }

    public void ButtonClicked ()
    {
        AudioManager.Instance.Play("ButtonClicked");
    }
}
