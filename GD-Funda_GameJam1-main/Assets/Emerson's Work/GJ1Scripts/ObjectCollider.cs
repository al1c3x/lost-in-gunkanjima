using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    [HideInInspector] public bool hit = false;
    private Collider col;

    void OnCollisionEnter(Collision collision)
    {
        if (this.GetComponent<Collider>().bounds.Intersects(collision.collider.bounds))
        {
            hit = true;
            col = collision.collider;
        }
    }

    private void Update()
    {
        if(col != null)
        {
            if (!this.GetComponent<Collider>().bounds.Intersects(col.bounds))
            {
                hit = false;
                col = null;
            }
        }
        else
        {
            hit = false;
        }
    }
}
