using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public AudioMixer[] audioMixer;
    public GameObject panelResume;
    public GameObject panelGameOver;
    public GameObject panelOption;
    public GameObject panelCredit;
    [SerializeField] private Text header;
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private bool show = false;
    public Texture2D cursorAim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Cursor.SetCursor(cursorAim, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !show)
        {
            showMenu();
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && show)
        {
            hideMenu();
        }


        if (TankControl.instance.isDead)
        {
            gameOver();
        }

    }

    public void setSFX(float volume)
    {
        audioMixer[1].SetFloat("SFX", volume);
    }
    public void setBGM(float volume)
    {
        audioMixer[0].SetFloat("BGM", volume);
    }
    public void gameOver()
    {
        header.text = GameManager.instance.result;
        score = GameManager.instance.score;
        scoreText.text = score.ToString();
        panelGameOver.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1;
        TankControl.instance.delayDie();
    }

    public void showMenu()
    {
        panelResume.SetActive(true);
        Time.timeScale = 0;
        show = true;
    }

    public void hideMenu()
    {
        panelResume.SetActive(false);
        panelOption.SetActive(false);
       
        Time.timeScale = 1;
        show = false;
    }

    public void OptionMenu()
    {
        panelResume.SetActive(false);
        panelOption.SetActive(true);
        show = true;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}
