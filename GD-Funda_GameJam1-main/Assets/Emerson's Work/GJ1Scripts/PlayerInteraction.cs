using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //Grabbed object rotation
    private float grabObjRot;

    private bool pickupCue = false;

    //Grabbed object and properties
    [HideInInspector] public GameObject grabbedObj;

    //Player's hands
    public GameObject hands;

    //Raycast
    private RaycastHit hit;

    //object release speed
    private float maxSpeed = 10.0f;
    private float releaseSpeed = 2.0f;
    private float currSpeed = 5.0f;

    //CharacterController component
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera camera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //if an objectt was grabbed
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3) 
            && hit.transform.GetComponent<Rigidbody>())
        {
            if (pickupCue == false)
                StartCoroutine(pickupObject());
            grabbedObj = hit.transform.gameObject;
        }
        //if there's no obj grabbed
        else if(Input.GetMouseButtonDown(0))
        {
            grabbedObj = null;
        }

        //move the grabobject
        if(grabbedObj && Input.GetMouseButton(0))
        {
            //sets the grabbed obj position relative to the hands position
            /*grabbedObj.transform.position = new Vector3(hands.transform.position.x,
                hands.transform.position.y, hands.transform.position.z);*/

            //checks if the objecGrabbed is colliding with other objs
            bool hitted;
            if (grabbedObj.GetComponent<ObjectCollider>() != null)
            {
                hitted = grabbedObj.GetComponent<ObjectCollider>().hit;
            }
            else
            {
                hitted = false;
            }
            //lowers the speed when hit to avoid object overlapping
            if (hitted)
            {
                currSpeed -= releaseSpeed * Time.deltaTime;
                currSpeed = Mathf.Clamp(currSpeed, 1.0f, maxSpeed);
                grabbedObj.GetComponent<Rigidbody>().velocity = currSpeed * (hands.transform.position - grabbedObj.transform.position);
            }
            //increasess the speed when hit to avoid object overlapping
            else
            {
                currSpeed += releaseSpeed * Time.deltaTime;
                currSpeed = Mathf.Clamp(currSpeed, 1.0f, maxSpeed);
                grabbedObj.GetComponent<Rigidbody>().velocity = currSpeed * (hands.transform.position - grabbedObj.transform.position);
            }
            //Debug.Log(currSpeed);
        }
        //object was released
        if (grabbedObj && Input.GetMouseButtonUp(0))
        {
            //adds a little force effect when it's being release
            grabbedObj.GetComponent<Rigidbody>().velocity = releaseSpeed * (hands.transform.position - grabbedObj.transform.position);
            //brings back the normal collision of the player and the object
            Physics.IgnoreCollision(grabbedObj.GetComponent<Collider>(), controller, false);
            //empties the hand
            grabbedObj = null;
        }
    }


    IEnumerator pickupObject()
    {
        pickupCue = true;
        SFXManager.SFXInstance.playSFX(SFXManager.SFXInstance.Hold);
        yield return new WaitForSeconds(5.0f);
        pickupCue = false;
    }

    /*
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (grabbedObj == hit.gameObject)
        {
            Debug.Log("Collided" + hit.transform.name);
            //ignores collision with the player to avoid buggy impacts
            Physics.IgnoreCollision(grabbedObj.GetComponent<Collider>(), controller, true);
        }
    }*/

}