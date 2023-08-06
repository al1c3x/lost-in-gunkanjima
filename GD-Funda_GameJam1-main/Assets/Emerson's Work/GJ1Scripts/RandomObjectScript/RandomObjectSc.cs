using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSc : MonoBehaviour
{
    //location names; locations to be added
    public enum Locations
    {
        FirstFloorGirlsRestroom,
        FirstFloorBoysRestroom,
        FirstFloorAuditoriumStage,
        SchoolEntrance,
        FirstFloorBoysUrinal,
        FirstFloorAuditoriumPodium,
        SecondFloorBoysRestroom,
        SecondFloorGirlsRestroom,
        SecondFloorBoysUrinal,
        ClosedDoorOnTheRooftop
    };


    //location of the spawnObj
    public string location = null;
    public string objName = null;
    private void Start()
    {

    }
    public void Constructor()
    {
        //assigns the name and location of the randomSpawnObj
        location = this.transform.parent.tag;
        objName = this.name;
    }
}

