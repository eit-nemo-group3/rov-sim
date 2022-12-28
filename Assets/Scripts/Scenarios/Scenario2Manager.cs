using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RovSim.Scenarios
{
    public class Scenario2Manager : MonoBehaviour
    {
        public Collider collisionBox;
        public Collider rovCollisionBox;
        public Collider surfaceCollisionBox;
        public TMP_Text questTitle;
        public TMP_Text questDescription;
        public AudioSource successSound;

        private int _scenarioStage;
        private Transform _grabber;
        private Transform _grabbedItem;
        private Image _image;

        private IEnumerator UpdateText(string text)
        {
            questDescription.SetText(text);
            questDescription.color = Color.green;
            questTitle.color = Color.green;

            yield return new WaitForSeconds(1);
            questDescription.color = Color.white;
            questTitle.color = Color.white;

        }

        // Start is called before the first frame update
        private void Start()
        {
            // Please set these manually in inspector, this gives a lot higher performance
            collisionBox = GameObject.Find("CollisionChamber").GetComponent<Collider>();
            rovCollisionBox = GameObject.Find("ROV").GetComponent<Collider>();
            _grabber = GameObject.Find("ObjectHandler").GetComponent<Transform>();
            _image = GameObject.Find("CoralImage").GetComponent<Image>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_grabber.childCount > 0)
            {
                _grabbedItem = _grabber.GetChild(0);
            }

            switch (_scenarioStage)
            {
                case 0:
                    questDescription.SetText(
                        "Explore further into the canyon. \n\nYou can navigate using the joysticks on your controller, or by using WASD and the arrow keys on your keyboard. You can tilt the camera using the joystick or by using Q and E on your keyboard");
                    if (collisionBox.bounds.Intersects(rovCollisionBox.bounds))
                    {
                        _scenarioStage = 1;
                        Debug.Log("Reached checkpoint");
                        StartCoroutine(UpdateText(
                            "Locate the coral at the end of the canyon \n\nPick up the coral by using the grabber with F to close and G to open"));
                        _image.enabled = true;
                        successSound.Play();
                    }

                    break;
                case 1:
                    if (_grabber.childCount > 0)
                    {
                        if (_grabbedItem.CompareTag("Grabbable"))
                        {
                            _scenarioStage = 2;
                            StartCoroutine(UpdateText("Return to the surface with your findings"));
                            Debug.Log("Inspection objective reached");
                            successSound.Play();
                        }
                        else
                        {
                            StartCoroutine(
                                UpdateText("You are holding the wrong coral, please find the following coral"));
                        }
                    }

                    break;
                case 2:
                    if (surfaceCollisionBox.bounds.Intersects(rovCollisionBox.bounds))
                    {
                        Debug.Log("reached surface");
                        SceneManager.LoadScene("MainMenu");
                    }

                    break;
            }
        }
    }
}
