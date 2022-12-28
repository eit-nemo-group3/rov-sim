using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace RovSim.Scenarios
{
    public class Scenario1Manager : MonoBehaviour
    {
        public Collider collisionBox;
        public Collider rovCollisionBox;
        public Collider surfaceCollisionBox;
        public Camera rovCamera;
        public float inspectionRange = 30f;
        public TMP_Text questTitle;
        public TMP_Text questDescription;
        public AudioSource successSound;
        public Animator transition;
        [SerializeField] private LayerMask layerMask;

        private int _scenarioStage;

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
        }

        // Update is called once per frame
        private void Update()
        {
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
                            "Locate the shipwreck at the end of the canyon \n\nMake sure to look directly at the shipwreck to identify any damages."));
                        successSound.Play();

                    }

                    break;
                case 1:
                    if (Physics.Raycast(rovCamera.transform.position,
                            rovCamera.transform.TransformDirection(Vector3.forward), out RaycastHit hit,
                            inspectionRange, layerMask))
                    {
                        _scenarioStage = 2;
                        StartCoroutine(UpdateText("Return to the surface with your findings"));
                        Debug.Log("Inspection objective reached");
                        successSound.Play();
                    }

                    break;
                case 2:
                    if (surfaceCollisionBox.bounds.Intersects(rovCollisionBox.bounds))
                    {
                        StartCoroutine(LoadLevel("MainMenu"));
                    }

                    break;
            }
        }


        private IEnumerator LoadLevel(string levelName)
        {
            transition.SetTrigger("Start");
            var asyncLoad = SceneManager.LoadSceneAsync(levelName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
