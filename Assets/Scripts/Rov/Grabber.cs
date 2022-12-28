using UnityEngine;

namespace RovSim.Rov
{
	public class Grabber : MonoBehaviour
	{
		private Animator _animator;
		private InputDetector _inputDetector;

		private void Awake()
		{
			_inputDetector = GetComponent<InputDetector>();
		}

		// Start is called before the first frame update
		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		// Update is called once per frame
		private void Update()
		{
			Grab();
		}

		private void Grab()
		{
			if (_inputDetector.ClosePressed)
			{
				_animator.SetBool("Open Grabber", true);
			}

			if (_inputDetector.OpenPressed)
			{
				_animator.SetBool("Open Grabber", false);
			}
		}
	}
}
