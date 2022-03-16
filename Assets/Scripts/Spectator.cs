using UnityEngine;

/// <summary>
/// A simple free camera to be added to a Unity game object.
/// 
/// Keys:
///	wasd / arrows	- movement
///	q/e 			- up/down (local space)
///	r/f 			- up/down (world space)
///	pageup/pagedown	- up/down (world space)
///	hold shift		- enable fast movement mode
///	right mouse  	- enable free look
///	mouse			- free look / rotation
///     
/// </summary>
namespace RovSim
{
	public class Spectator : MonoBehaviour
	{
		/// <summary>
		/// Normal speed of camera movement.
		/// </summary>
		public float movementSpeed = 3f;

		/// <summary>
		/// Speed of camera movement when shift is held down,
		/// </summary>
		public float fastMovementSpeed = 10f;

		/// <summary>
		/// Sensitivity for free look.
		/// </summary>
		public float freeLookSensitivity = 3f;

		/// <summary>
		/// Amount to zoom the camera when using the mouse wheel.
		/// </summary>
		public float zoomSensitivity = 10f;

		/// <summary>
		/// Amount to zoom the camera when using the mouse wheel (fast mode).
		/// </summary>
		public float fastZoomSensitivity = 50f;

		/// <summary>
		/// Set to true when free looking (on right mouse button).
		/// </summary>
		private bool looking = false;

		[SerializeField] public Spectator test;

		void Update()
		{
			var fastMode = UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
			var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

			if (UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
			}

			if (UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.RightArrow))
			{
				transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
			}

			if (UnityEngine.Input.GetKey(KeyCode.Space))
			{
				transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
			}

			if (UnityEngine.Input.GetKey(KeyCode.C))
			{
				transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
			}

			if (UnityEngine.Input.GetKey(KeyCode.R) || UnityEngine.Input.GetKey(KeyCode.PageUp))
			{
				transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
			}

			if (UnityEngine.Input.GetKey(KeyCode.F) || UnityEngine.Input.GetKey(KeyCode.PageDown))
			{
				transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
			}

			if (looking)
			{
				float newRotationX = transform.localEulerAngles.y + UnityEngine.Input.GetAxis("Mouse X") * freeLookSensitivity;
				float newRotationY = transform.localEulerAngles.x - UnityEngine.Input.GetAxis("Mouse Y") * freeLookSensitivity;
				transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
			}

			float axis = UnityEngine.Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0)
			{
				var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
				transform.position = transform.position + transform.forward * axis * zoomSensitivity;
			}

			if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse1))
			{
				StartLooking();
			}
			else if (UnityEngine.Input.GetKeyUp(KeyCode.Mouse1))
			{
				StopLooking();
			}
		}

		void OnDisable()
		{
			StopLooking();
		}

		/// <summary>
		/// Enable free looking.
		/// </summary>
		public void StartLooking()
		{
			looking = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		/// <summary>
		/// Disable free looking.
		/// </summary>
		public void StopLooking()
		{
			looking = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		public void Up()
		{
			transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
		}

		public void Down()
		{
			transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
		}
	}
}