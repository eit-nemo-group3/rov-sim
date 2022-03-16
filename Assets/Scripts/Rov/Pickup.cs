using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RovSim.Input;

public class Pickup : MonoBehaviour
{
    private GameObject heldObj;
    private GameObject rb;
    public Transform holdParent;
    private float moveForce = 250f;
    [SerializeField] private bool canGrab;
    private InputDetector _inputDetector;
    Rigidbody temp;

		private void Awake()
		{
			_inputDetector = GetComponent<InputDetector>();
		}
    // Update is called once per frame
    void Update()
    {   
        if(_inputDetector.ClosePressed && canGrab == true){
            if(heldObj == null)
            {
                PickupObject(rb);
                temp = rb.GetComponent<Rigidbody>();
                temp.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("picked up");
            }
            
        }
        if(_inputDetector.OpenPressed)
        {
            if(heldObj != null){
                DropObject();
                temp.constraints = RigidbodyConstraints.None;
            }    
        }

        if(heldObj != null)
        {
           MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Grabbable"){
            canGrab = true;
            rb = collision.gameObject;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Grabbable"){
            canGrab = false;
            rb = null;
        }
    }
}
