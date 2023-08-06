using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goMain()
    {
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.ButtonClick);
        LoaderScript.loadScene(0, SceneManager.sceneCountInBuildSettings - 1);
        Debug.Log("Main Screen");
        //Debug.Log("Game Screen");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }
}
