using UnityEngine.UI;
using UnityEngine;

namespace RovSim
{
	public class Compass : MonoBehaviour
	{
		public RawImage compassImage;
		public Transform player;

		public void Update()
		{
			// Get a handle on the Image's uvRect
			compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);
		}
	}
}
