using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Scenario02 : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    public Collider collisionBox;
    public Collider ROVCollisionBox;
    public Collider SurfaceCollisionBox;
    public Camera ROVCamera;
    private int state = 0;
    public float inspectionRange = 30f;
    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public AudioSource successSound;
    
    private Transform grabber;

    IEnumerator UpdateText(string text)
    {
        questDescription.SetText(text);
        questDescription.color = Color.green;
        questTitle.color = Color.green;

        yield return new WaitForSeconds(1);
        questDescription.color = Color.white;
        questTitle.color = Color.white;

    }

    // Start is called before the first frame update
    void Start()
    {
        // Please set these manually in inspector, this gives a lot higher performance
        collisionBox = GameObject.Find("CollisionChamber").GetComponent<Collider>();
        ROVCollisionBox = GameObject.Find("ROV").GetComponent<Collider>();
        grabber = GameObject.Find("ObjectHandler").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0){
            questDescription.SetText("Explore further into the canyon. \n\nYou can navigate using the joysticks on your controller, or by using WASD and the arrow keys on your keyboard. You can tilt the camera using the joystick or by using Q and E on your keyboard");
            if (collisionBox.bounds.Intersects(ROVCollisionBox.bounds))
            {
                state = 1;
                Debug.Log("Reached checkpoint");
                StartCoroutine(UpdateText("Locate the coral at the end of the canyon \n\nPick up the coral by using the grabber with F to close and G to open"));
                successSound.Play();
                
            }
        }

        if (state == 1){
            if(grabber.childCount > 0){
                    state = 2;
                    StartCoroutine(UpdateText("Return to the surface with your findings"));
                    Debug.Log("Inspection objective reached");
                successSound.Play();
            }
        }

        if (state == 2){
            if (SurfaceCollisionBox.bounds.Intersects(ROVCollisionBox.bounds))
            {
                Debug.Log("reached surface");
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
