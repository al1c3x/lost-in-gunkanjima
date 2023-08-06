using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSFXUpdate : MonoBehaviour
{
    float EerieTime = 0, GhostSound = 0;

    void FixedUpdate()
    {
        EerieTime += Time.deltaTime;
        GhostSound += Time.deltaTime;

        if (EerieTime >= 25)
        {
            SFXManager.SFXInstance.playEerie();
            EerieTime = 0;
        }

        if (GhostSound >= 45)
        {
            SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.Ghost);
            GhostSound = 0;
        }
    }
}
