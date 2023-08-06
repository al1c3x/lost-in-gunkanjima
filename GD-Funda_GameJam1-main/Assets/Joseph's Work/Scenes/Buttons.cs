using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject MainB;
    [SerializeField] private GameObject hplayB;
    [SerializeField] private GameObject MainBg;
    [SerializeField] private GameObject hplayBg;
    // Start is called before the first frame update
    void Start()
    {
        this.hplayB.SetActive(false);
        this.hplayBg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.ButtonClick);
        Application.Quit();
        Debug.Log("Exit");

    }
    public void StartGame()
    {
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.ButtonClick);
        //LoaderScript.unloadScene();
        LoaderScript.loadScene(1, SceneManager.sceneCountInBuildSettings - 1);
        Debug.Log("Loading Screen");
        Debug.Log("Game Screen");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HplayGame()
    {
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.ButtonClick);
        this.hplayB.SetActive(true);
        this.MainB.SetActive(false);
        this.MainBg.SetActive(false);
        this.hplayBg.SetActive(true);
    }

    public void rMain()
    {
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.ButtonClick);
        this.hplayBg.SetActive(false);
        this.hplayB.SetActive(false);
        this.MainB.SetActive(true);
        this.MainBg.SetActive(true);
    }
}

