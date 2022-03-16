using UnityEngine;
using RovSim.Input;

namespace RovSim.Rov
{
	/// <summary>
	/// The Movement component requires a game object with Camera, Rigidbody and InputDetector components.
	/// <para />
	/// It handles input from the InputDetector, and adjusts the Camera relative to the Rigidbody.
	/// </summary>
	[RequireComponent(typeof(Camera))]
	//[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(InputDetector))]
	public class CameraControl : MonoBehaviour
	{
		/// <summary>
		/// Modifier for how quickly the ROV should rotate.
		/// Default value 1.
		/// </summary>
		[Tooltip("Modifier for how quickly the camera should tilt. Default value 1.")]
		[SerializeField]
		private float tiltSensitivity = 1.0f;

		/// <summary>
		/// Modifier for how much the camera can tilt. 
		/// Default value 45, can not be less than 0 or bigger than 180.
		/// </summary>
		[Tooltip("Modifier for how much the camera can tilt. Default value 45, can not be less than 0 or bigger than 90.")]
		[SerializeField]
		private float maxAngle = 45;

		private Camera _camera;
		//private Rigidbody _body;
		private InputDetector _inputDetector;

		private void Awake()
		{
			_camera = GetComponent<Camera>();
			//_body = GetComponent<Rigidbody>();
			_inputDetector = GetComponent<InputDetector>();
		}

		private void FixedUpdate()
		{
			// Tilt camera up
			handleCameraTilt(_inputDetector.CameraTiltUpPressed, -tiltSensitivity);

			// Tilt camera down
			handleCameraTilt(_inputDetector.CameraTiltDownPressed, tiltSensitivity);
		}

		private void handleCameraTilt(bool inputPressed, float rotation)
		{
			if (inputPressed) 
			{
				// Finding new roation
				float newRotationX = transform.localEulerAngles.x + rotation;

				// Checking that roation does not exceed max angle
				if (newRotationX > maxAngle & newRotationX < 180) 
				{
					newRotationX = maxAngle;
				}
				else if (newRotationX < 360 - maxAngle  & newRotationX > 180)
				{
					newRotationX = 360 - maxAngle;
				}

				// Applying new rotation
				transform.localEulerAngles = new Vector3(
					newRotationX,
					transform.localEulerAngles.y,
					transform.localEulerAngles.z
				);
			}
		}
	}
}
