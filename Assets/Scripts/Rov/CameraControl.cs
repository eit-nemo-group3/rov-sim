using UnityEngine;

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

		private InputDetector _inputDetector;

		private void Awake()
		{
			_inputDetector = GetComponent<InputDetector>();
		}

		private void FixedUpdate()
		{
			// Tilt camera up
			HandleCameraTilt(_inputDetector.CameraTiltUpPressed, -tiltSensitivity);

			// Tilt camera down
			HandleCameraTilt(_inputDetector.CameraTiltDownPressed, tiltSensitivity);
		}

		private void HandleCameraTilt(bool inputPressed, float rotation)
		{
			if (!inputPressed) return;

			var currentTransform = transform;
			var previousAngles = currentTransform.localEulerAngles;

			// Finding new roation
			var newRotationX = previousAngles.x + rotation;

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
			currentTransform.localEulerAngles = new Vector3(
				newRotationX,
				previousAngles.y,
				previousAngles.z
			);
		}
	}
}
