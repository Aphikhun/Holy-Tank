using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer[] audioMixer;
    public GameObject panelOption;
    public GameObject panelCredit;

    [SerializeField] private bool show = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && show)
        {
            Debug.Log("close");
            hideMenu();
        }
    }
    public void hideMenu()
    {
        panelOption.SetActive(false);
        panelCredit.SetActive(false);
        show = false;
    }
    public void OptionMenu()
    {
        panelOption.SetActive(true);
        show = true;
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void credit()
    {
        panelCredit.SetActive(true);
        show = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void setSFX(float volume)
    {
        audioMixer[1].SetFloat("SFX", volume);
    }
    public void setBGM(float volume)
    {
        audioMixer[0].SetFloat("BGM", volume);
    }
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
