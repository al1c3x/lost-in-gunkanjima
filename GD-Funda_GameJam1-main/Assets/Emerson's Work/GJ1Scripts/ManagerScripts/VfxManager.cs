using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    //instance
    [HideInInspector] public static VfxManager Instance;
    public CustomEffects[] effectList;
    private void Awake()
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

    //instantiate the effect to the world
    public void instantiateEffect(string name, Vector3 pos, float duration)
    {
        GameObject GO = null;
        //iterates the list 
        foreach (var item in effectList)
        {
            if(item.name == name)
            {
                GO = item.effect as GameObject;
            }
        }
        GameObject newGO = Instantiate(GO, pos, Quaternion.identity) as GameObject;
        newGO.GetComponent<EffectsScript>().destructionTimer = duration;
    }


    public GameObject getEffectGO(string name)
    {
        GameObject GO = null;
        foreach (var item in effectList)
        {
            if (item.name == name)
            {
                GO = item.effect as GameObject;
            }
        }
        return GO;
    }


}
