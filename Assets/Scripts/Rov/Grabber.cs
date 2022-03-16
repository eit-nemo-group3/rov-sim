using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RovSim.Input;


public class Grabber : MonoBehaviour
{

    Animator animator;
	private InputDetector _inputDetector;

		private void Awake()
		{
			_inputDetector = GetComponent<InputDetector>();
		}

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
		{
			grab();
		}
    private void grab(){
        if (_inputDetector.ClosePressed){
        animator.SetBool("Open Grabber", true);
        }
     
        if (_inputDetector.OpenPressed){
        animator.SetBool("Open Grabber", false);
        }
    }
    
}
