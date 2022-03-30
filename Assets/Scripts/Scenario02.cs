// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;


// public class Scenario02 : MonoBehaviour
// {

//     [SerializeField] LayerMask layerMask;
//     public Collider collisionBox;
//     public Collider ROVCollisionBox;
//     public Camera ROVCamera;
//     private int state = 0;
//     public float inspectionRange = 30f;
//     public TMP_Text questTitle;
//     public TMP_Text questDescription;
//     public AudioSource successSound;


//     IEnumerator UpdateText(string text)
//     {
//         questDescription.SetText(text);
//         questDescription.color = Color.green;
//         questTitle.color = Color.green;

//         yield return new WaitForSeconds(1);
//         questDescription.color = Color.white;
//         questTitle.color = Color.white;

//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         // Please set these manually in inspector, this gives a lot higher performance
//         collisionBox = GameObject.Find("CollisionChamber").GetComponent<Collider>();
//         ROVCollisionBox = GameObject.Find("ROV").GetComponent<Collider>();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (state == 0){
//             questDescription.SetText("Explore further into the canyon. \n\nYou can navigate using the joysticks on your controller, or by using WASD and the arrow keys on your keyboard. You can tilt the camera using the joystick or by using Q and E on your keyboard");
//             if (collisionBox.bounds.Intersects(ROVCollisionBox.bounds))
//             {
//                 state = 1;
//                 Debug.Log("Reached checkpoint");
//                 StartCoroutine(UpdateText("Locate the shipwreck at the end of the canyon \n\nMake sure to look directly at the shipwreck to identify any damages."));
//                 successSound.Play();
                
//             }
//         }

//         if (state == 1){
//             if(Physics.Raycast(ROVCamera.transform.position, ROVCamera.transform.TransformDirection (Vector3.forward), out RaycastHit hit, inspectionRange, layerMask)){
//                     state = 2;
//                     StartCoroutine(UpdateText("Return to the surface with your findings"));
//                     Debug.Log("Inspection objective reached");
//                 successSound.Play();
//             }
//         }
        
//     }
// }
