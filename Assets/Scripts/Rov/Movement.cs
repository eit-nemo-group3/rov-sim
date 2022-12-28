using UnityEngine;

namespace RovSim.Rov
{
	/// <summary>
	/// The Movement component requires a game object with Rigidbody and InputDetector components.
	/// <para />
	/// It handles input from the InputDetector, and adds forces to the Rigidbody in the corresponding directions.
	/// </summary>
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(InputDetector))]
	public class Movement : MonoBehaviour
	{
		/// <summary>
		/// Modifier that the object's vertical force is multiplied with.
		/// Default value 1.
		/// </summary>
		[Tooltip("Modifier that the ROV's vertical force is multiplied with. Default value 1.")]
		[SerializeField]
		private float verticalThrust = 1.0f;

		/// <summary>
		/// Modifier that the object's horizontal force is multiplied with.
		/// Default value 1.
		/// </summary>
		[Tooltip("Modifier that the ROV's horizontal force is multiplied with. Default value 1.")]
		[SerializeField]
		private float horizontalThrust = 1.0f;

		/// <summary>
		/// Modifier for how quickly the object should rotate.
		/// Default value 1.
		/// </summary>
		[Tooltip("Modifier for how quickly the ROV should rotate. Default value 1.")]
		[SerializeField]
		private float rotationSensitivity = 1.0f;

		private Rigidbody _body;
		private InputDetector _inputDetector;

		private void Awake()
		{
			_body = GetComponent<Rigidbody>();
			_inputDetector = GetComponent<InputDetector>();
		}

		private void FixedUpdate()
		{
			// Move forward
			HandleMovement(_inputDetector.MoveForwardPressed, Vector3.forward, horizontalThrust);

			// Move back
			HandleMovement(_inputDetector.MoveBackPressed, Vector3.back, horizontalThrust);

			// Move left
			HandleMovement(_inputDetector.MoveLeftPressed, Vector3.left, horizontalThrust);

			// Move right
			HandleMovement(_inputDetector.MoveRightPressed, Vector3.right, horizontalThrust);

			// Move up
			HandleMovement(_inputDetector.MoveUpPressed, Vector3.up, verticalThrust);

			// Move down
			HandleMovement(_inputDetector.MoveDownPressed, Vector3.down, verticalThrust);

			// Rotate left
			HandleHorizontalRotation(_inputDetector.RotateLeftPressed, -rotationSensitivity);

			// Rotate right
			HandleHorizontalRotation(_inputDetector.RotateRightPressed, rotationSensitivity);
		}

		/// <summary>
		/// When inputPressed = true, applies a force to the game object
		/// in the given direction and multiplied with the given thrust.
		/// </summary>
		private void HandleMovement(bool inputPressed, Vector3 directionVector, float thrust)
		{
			if (!inputPressed) return;

			var relativeVector = _body.transform.TransformDirection(directionVector);
			_body.AddForce(relativeVector * thrust, ForceMode.Force);
		}

		/// <summary>
		/// When inputPressed = true, rotates the game object according to the given rotation value.
		/// </summary>
		private void HandleHorizontalRotation(bool inputPressed, float rotation)
		{
			if (!inputPressed) return;

			var currentTransform = transform;
			var previousAngles = currentTransform.localEulerAngles;

			currentTransform.localEulerAngles = new Vector3(
				previousAngles.x,
				previousAngles.y + rotation,
				previousAngles.z
			);
		}
	}
}
