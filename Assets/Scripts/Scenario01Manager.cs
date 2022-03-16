using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario01Manager : MonoBehaviour
{

     [SerializeField] LayerMask layerMask;
    public Collider collisionBox;
    public Collider ROVCollisionBox;
    public Collider inspectionObjective;
    private int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Please set these manually in inspector, this gives a lot higher performance
        collisionBox = GameObject.Find("CollisionChamber").GetComponent<Collider>();
        ROVCollisionBox = GameObject.Find("ROV").GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0){
            if (collisionBox.bounds.Intersects(ROVCollisionBox.bounds))
            {
                state = 1;
                Debug.Log("Reached checkpoint");
            }
        }

        if (state == 1){
            if(Physics.Raycast(ROVCollisionBox.transform.position, ROVCollisionBox.transform.TransformDirection (Vector3.forward), out RaycastHit hit, 100f, layerMask)){
                    state = 2;
                    Debug.Log("Inspection objective reached");
            }
        }
        
    }
}
