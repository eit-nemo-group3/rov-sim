using UnityEngine;
using UnityEngine.InputSystem;

namespace RovSim.Input
{
	public class InputDetector : MonoBehaviour
	{
		public bool MoveUpPressed { get; private set; }
		public bool MoveDownPressed { get; private set; }
		public bool MoveForwardPressed { get; private set; }
		public bool MoveBackPressed { get; private set; }
		public bool MoveLeftPressed { get; private set; }
		public bool MoveRightPressed { get; private set; }
		public bool RotateLeftPressed { get; private set; }
		public bool RotateRightPressed { get; private set; }
		public bool ClosePressed { get; private set; }
		public bool OpenPressed { get; private set; }
		public bool CameraTiltUpPressed { get; private set; }
		public bool CameraTiltDownPressed { get; private set; }
		public bool enableDebug;

		public void PressClose(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("close pressed");
				ClosePressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("close released");
				ClosePressed = false;
			}
		}

		public void PressOpen(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("open pressed");
				OpenPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("open released");
				OpenPressed = false;
			}
		}


		public void PressMoveUp(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("move up pressed");
				MoveUpPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("up released");
				MoveUpPressed = false;
			}
		}

		public void PressMoveDown(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("down pressed");
				MoveDownPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("down released");
				MoveDownPressed = false;
			}
		}

		public void PressMoveForward(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("forward pressed");
				MoveForwardPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("forward released");
				MoveForwardPressed = false;
			}
		}

		public void PressMoveBack(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("back pressed");
				MoveBackPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("back released");
				MoveBackPressed = false;
			}

		}

		public void PressMoveLeft(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("move left pressed");
				MoveLeftPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("move left released");
				MoveLeftPressed = false;
			}
		}

		public void PressMoveRight(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("move right pressed");
				MoveRightPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("move right released");
				MoveRightPressed = false;
			}
		}

		public void PressRotateLeft(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("rotate left pressed");
				RotateLeftPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("rotate left released");
				RotateLeftPressed = false;
			}
		}

		public void PressRotateRight(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("rotate right pressed");
				RotateRightPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("rotate right released");
				RotateRightPressed = false;
			}
		}

		public void PressTiltCameraUp(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("camera tilt up pressed");
				CameraTiltUpPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("camera tilt up released");
				CameraTiltUpPressed = false;
			}
		}

		public void PressTiltCameraDown(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (enableDebug) Debug.Log("camera tilt down pressed");
				CameraTiltDownPressed = true;
			}
			else if (context.canceled)
			{
				if (enableDebug) Debug.Log("camera tilt down released");
				CameraTiltDownPressed = false;
			}
		}
	}
}
