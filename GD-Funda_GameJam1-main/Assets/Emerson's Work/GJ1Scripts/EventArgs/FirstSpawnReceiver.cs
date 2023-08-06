using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class FirstSpawnReceiver : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Start()
    {
        RandomPickerSc.Instance.OnFirstSpawn += randomizePLspwn;
    }

    private void OnDisable()
    {
        RandomPickerSc.Instance.OnFirstSpawn -= randomizePLspwn;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private RandomPickerSc rpSC;
    public void randomizePLspwn(object sender, GameObject args)
    {
        rpSC = RandomPickerSc.Instance;
        //randomly picks a spawn point location for the Player and Headmaster
        if (rpSC.playerSpawnPoints.Count > 0)
        {
            spawnPlynHdms(UnityEngine.Random.Range(0, rpSC.playerSpawnPoints.Count));
        }
    }
    public void spawnPlynHdms(int index)
    {
        if (index == -1)
        {
            Debug.Log("Null PlayerSpwn");
        }
        //instantiates the player and headmaster and place it on the spawnLocation
        else
        {
            /*
             * We've assign it to a Gameobject variable since setting object transform
             * to a parent shouldn't be a prefab type
            */
    
            GameObject player =
            GameObject.Instantiate(rpSC.playerObj,
                rpSC.playerSpawnPoints[index].transform.GetChild(0).position,
                Quaternion.identity) as GameObject;
            GameObject headMaster =
            GameObject.Instantiate(rpSC.headMasterObj,
                rpSC.playerSpawnPoints[index].transform.GetChild(1).position,
                Quaternion.Euler(0,180,0)) as GameObject;

            player.transform.parent = rpSC.playerSpawnPoints[index].transform.GetChild(0).transform;
            headMaster.transform.parent = rpSC.playerSpawnPoints[index].transform.GetChild(1).transform;
        }
    }

}
