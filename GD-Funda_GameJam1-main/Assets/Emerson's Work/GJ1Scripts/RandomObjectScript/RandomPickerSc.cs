using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class RandomPickerSc : MonoBehaviour
{
    //Chosen object
    [HideInInspector] public GameObject chosenGO;
    //location names
    public enum Locations
    {
        Restroom
    };

    //Gameobject for the player and headmaster
    public GameObject playerObj;
    public GameObject headMasterObj;

    //List of spawnpoints for the player and headmaster pair
    public List<GameObject> playerSpawnPoints = new List<GameObject>();
    //List of spawnpoints for the object
    public List<GameObject> objectSpawnPoints = new List<GameObject>();
    //List of randomize objects
    public List<GameObject> randObjs = new List<GameObject>();

    //instance
    [HideInInspector] public static RandomPickerSc Instance;
    //event args
    public EventHandler<GameObject> OnFirstSpawn;
    public EventHandler<GameObject> OnRandomObj;

    public Text textboxContent;
    public Text locationContent;

    public void Awake()
    {
        //assigns the one instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //destroys the duplicate gameObject 
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //calls the events for the first spawn
        if (Instance.OnFirstSpawn != null)
        {
            Instance.OnFirstSpawn(this, RandomPickerSc.Instance.gameObject);
        }
        else
        {
            Debug.Log("Null OnFirstSpawn");
        }
        //calls the events for the random object picker
        if (Instance.OnRandomObj != null)
        {
            Instance.OnRandomObj(this, RandomPickerSc.Instance.gameObject);
        }
        else
        {
            Debug.Log("Null OnRandomObj");
        }

        //adds the riddle to the textbox below
        switchCaseTextBoxContent(chosenGO);
        //adds the location of the object at the top right corner
        locationContent.text = Instance.chosenGO.GetComponent<RandomObjectSc>().location;

    }

    private void switchCaseTextBoxContent(GameObject GObject)
    {
        switch (GObject.name)
        {
            case "45-45-90 triangle(Clone)":
                textboxContent.text = "I am triangle-shaped.I am made of plastic or wood.";
                break;
            case "attendance book(Clone)":
                textboxContent.text = "I am thin. I have a list of students in a class.";
                break;
            case "big brown notebook(Clone)":
                textboxContent.text = "I am thin. I am broad and empty but I shimmer with the color brown on my cover.";
                break;
            case "black backpack(Clone)":
                textboxContent.text = "I carry books and supplies. I am that round, black object with straps on my backsides.";
                break;
            case "black book(Clone)":
                textboxContent.text = "I can be thin or thick. You can read me but do not judge my black cover.";
                break;
            case "black notebook(Clone)":
                textboxContent.text = "I have round spines. My cover is black and my paper inside has a lot of lines. ";
                break;
            case "blue chalk(Clone)":
                textboxContent.text = "I am a short stick. I am blue but you can write with me on the blackboard.";
                break;
            case "El Jorge book(Clone)":
                textboxContent.text = "I can be thin or thick. El Jorge is my name and do not judge the cover.";
                break;
            case "green book(Clone)":
                textboxContent.text = "I have a lot of information. My cover is green and I have a lot of paper.";
                break;
            case "orange book(Clone)":
                textboxContent.text = "I am thick but students love to read me. Orange is the new rock and I have a guitar on me.";
                break;
            case "pencil case(Clone)":
                textboxContent.text = "Cool students here have this with a sharpener as well as an eraser holder.";
                break;
            case "projector(Clone)":
                textboxContent.text = "I am white, but my breath is the rainbow. The class watches movies with me.";
                break;
            case "protractor(Clone)":
                textboxContent.text = "I am shaped like the half moon. I am made of plastic or wood.";
                break;
            case "red ballpen(Clone)":
                textboxContent.text = "I have a red case, which also represents the color of my ink.";
                break;
            case "yellow chalk(Clone)":
                textboxContent.text = "I am a short stick. I am yellow but you can write with me on the blackboard.";
                break;
        }
    }


}
