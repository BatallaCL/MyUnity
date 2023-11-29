using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public Rigidbody selfRB;
    public float force;
    public Vector3 posotion;
    public bool hasCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        selfRB.AddForce(transform.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.GetComponent<ArrowControl>())
        {
            selfRB.constraints = RigidbodyConstraints.FreezeAll;
            hasCollision = true;

            //if(collision.gameObject.GetComponent<Rigidbody>())
        }
    }
}
