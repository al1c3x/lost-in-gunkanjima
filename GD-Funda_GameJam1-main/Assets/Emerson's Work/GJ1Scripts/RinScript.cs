using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RinScript : MonoBehaviour
{
    private Animator RinAnim;
    [SerializeField] private float idle_Interval = 10.0f;
    [SerializeField] private float bow_Interval = 1.0f;
    Vector3 originPos;
    public GameObject winCanvas;
    public GameObject wrongObjectCanvas;
    public GameObject loseCanvas;
    private float timerTicks = 180.0f;

    private bool isLastFiveMins = false;
    private bool isLastOneMin = false;


    private void Start()
    {
        RinAnim = this.GetComponent<Animator>();
        originPos = this.transform.position;
        
    }

    private float winTimer = 3.0f;
    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            winTimer -= Time.deltaTime;
            if(winTimer <= 0.0f)
            {
                win = false;
                winTimer = 3.0f;
                //switch to win scene
                switchToWinScene();
            }
        }

        timerTicks -= Time.deltaTime;
        Debug.Log(timerTicks);

        //removes any force 
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.position = new Vector3(originPos.x, 
            this.transform.position.y, originPos.z);

        idle_Interval -= Time.deltaTime;
        if(idle_Interval <= 0.0f)
        {
            bow_Interval -= Time.deltaTime;
                RinAnim.SetBool("bow", true);
            if(bow_Interval <= 0.0f)
            {
                idle_Interval = 10.0f;
            }
        }
        else
        {
            RinAnim.SetBool("bow", false);
        }

        if ((int)timerTicks == 90 && isLastFiveMins == false)
        {
            //play 5 mins left sfx
            SFXManager.SFXInstance.playSFXTimerHalf();
            isLastFiveMins = true;
        }

        if((int)timerTicks == 30 && isLastOneMin == false)
        {
            //play 1 min left sfx
            SFXManager.SFXInstance.playSFXTimerOne();
            isLastOneMin = true;
        }
        
        if (timerTicks < 0.0f)
        {
            timerTicks = 10000.0f;
            loseCanvas = Instantiate(loseCanvas);
            Destroy(loseCanvas, 3f);
            //switch to lose scene
            switchToLoseScene();
        }

    }

    private bool win = false;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject chosenGO = RandomPickerSc.Instance.chosenGO;
        GameObject collidedGO = collision.gameObject;
        //checks first if the object delivered is a part of the RandomObjectList
        if(collidedGO.GetComponent<ObjectCollider>() != null)
        {
            if (collidedGO.GetComponent<RandomObjectSc>() != null)
            {
                //gets the two components of the right obj and the delivered obj
                RandomObjectSc sent = collidedGO.GetComponent<RandomObjectSc>();
                RandomObjectSc chosen = chosenGO.GetComponent<RandomObjectSc>();
                //now checks with the condition of location and name if the item delivered is right
                if (chosen.location == sent.location && chosen.objName == sent.objName)
                {
                    //player wins
                    Debug.Log("Arigato senpai!");
                    VfxManager.Instance.instantiateEffect("Heart", this.transform.parent.gameObject.transform.position, 1.0f);
                    winCanvas = Object.Instantiate(winCanvas);
                    Destroy(winCanvas, 3f);
                    //switch to win scene
                    //switchToWinScene();
                    win = true;
                }
            }
            else
            {
                GameObject newwrongObjectCanvas = Instantiate(wrongObjectCanvas);
                Destroy(newwrongObjectCanvas, 3f);
                Debug.Log("Wrong OBJECT!");
                VfxManager.Instance.instantiateEffect("DustSmoke_A", this.transform.parent.gameObject.transform.position, 1.0f);
            }
        }
    }

    private void switchToLoseScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        LoaderScript.loadScene(2, SceneManager.sceneCountInBuildSettings - 1);
    }

    private void switchToWinScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        LoaderScript.loadScene(3, SceneManager.sceneCountInBuildSettings - 1);
        //LoaderScript.loadScene();//2, SceneManager.sceneCountInBuildSettings - 1);
    }
}
