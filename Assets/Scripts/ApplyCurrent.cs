using System.Collections.Generic;
using UnityEngine;

namespace RovSim
{
    public class ApplyCurrent : MonoBehaviour
    {
        /// <summary>
        /// Modifier for current strength.
        /// Default value 1.
        /// </summary>
        [Tooltip("Modifier for current strength. Default value 1.")] [SerializeField]
        private float currentForce = 1.0f;

        /// <summary>
        /// Modfier for current direction in degrees.
        /// Default value 0, has to be between 0 and 360.
        /// </summary>
        [Tooltip("Modfier for current direction in degrees. Default value 0, has to be between 0 and 360.")]
        [SerializeField]
        private float forceDirection;

        // List of objects in the current area
        private List<GameObject> _affectedObjects;

        // Forcevector
        private Vector3 _forceVector;

        // Body that force is applied to
        private Rigidbody _body;

        // Forcedirection converted to radians
        private float _forceDirectionRadian;

        private void Awake()
        {
            _affectedObjects = new List<GameObject>();

            // Finding direction in radians
            _forceDirectionRadian = 2f * Mathf.PI * (forceDirection / 360f);

            // Calculating forcevector
            _forceVector = CalculateForceVector(currentForce, _forceDirectionRadian);

        }

        // Adding objects that enter the area to list
        private void OnTriggerEnter(Collider collidee)
        {
            _affectedObjects.Add(collidee.gameObject);
        }

        // Removing objects that leave the area from list
        private void OnTriggerExit(Collider collidee)
        {
            _affectedObjects.Remove(collidee.gameObject);
        }

        private void FixedUpdate()
        {
            // Adding force to all objects in area
            foreach (var affectedObject in _affectedObjects)
            {
                try
                {
                    _body = affectedObject.GetComponent<Rigidbody>();
                    _body.AddForce(_forceVector);
                }
                catch
                {
                    // Dont do anything if object does not have rigidbody
                }
            }
        }

        // Converting direction and force to forcevector
        private static Vector3 CalculateForceVector(float force, float direction)
        {
            return new Vector3(
                Mathf.Cos(direction) * force,
                0,
                Mathf.Sin(direction) * force
            );
        }
    }
}
