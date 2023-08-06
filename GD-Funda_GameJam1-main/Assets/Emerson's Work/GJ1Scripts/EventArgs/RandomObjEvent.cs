using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class RandomObjEvent : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Start()
    {
        RandomPickerSc.Instance.OnRandomObj += randomizeOBJspawn;
    }

    private void OnDisable()
    {
        RandomPickerSc.Instance.OnRandomObj -= randomizeOBJspawn;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private RandomPickerSc rpSC;
    private GameObject randObj;

    public void randomizeOBJspawn(object sender,  GameObject args)
    {
        rpSC = RandomPickerSc.Instance;
        int spwnInd = -1, objIndx = -1;
        //randomly picks a spawn point location for random Object
        if (rpSC.objectSpawnPoints.Count > 0)
        {
            spwnInd = UnityEngine.Random.Range(0, rpSC.objectSpawnPoints.Count);
        }
        if (rpSC.randObjs.Count > 0)
        {
            objIndx = UnityEngine.Random.Range(0, rpSC.randObjs.Count);
        }
        spawnObject(spwnInd, objIndx);
    }

    public void spawnObject(int spnIndex, int objIndex)
    {
        if (spnIndex == -1 || objIndex == -1)
        {
            Debug.Log("Null ObjSpawnpoints or Objects");
        }
        //instantiates the object and place it on the spawnLocation
        else
        {
            /*
             * We've assign it to a Gameobject variable since setting object transform
             * to a parent shouldn't be a prefab type
            */
            randObj =
            GameObject.Instantiate(rpSC.randObjs[objIndex],
                rpSC.objectSpawnPoints[spnIndex].transform.position,
                Quaternion.identity) as GameObject;
            //place the go to the assigned parent (organize)
            randObj.transform.parent = rpSC.objectSpawnPoints[spnIndex].transform;
            //assigns the location and name of the object
            randObj.GetComponent<RandomObjectSc>().Constructor();
            rpSC.chosenGO = randObj;
            Debug.Log(randObj.GetComponent<RandomObjectSc>().objName);

        }
    }

}
