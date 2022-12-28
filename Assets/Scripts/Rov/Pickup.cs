using UnityEngine;

namespace RovSim.Rov
{
    public class Pickup : MonoBehaviour
    {
        public Transform holdParent;
        [SerializeField] private bool canGrab;

        private const float MoveForce = 250f;
        private GameObject _heldObj;
        private GameObject _body;
        private InputDetector _inputDetector;
        private Rigidbody _temp;

        private void Awake()
        {
            _inputDetector = GetComponent<InputDetector>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_inputDetector.ClosePressed && canGrab)
            {
                if (_heldObj is null)
                {
                    PickupObject(_body);
                    _temp = _body.GetComponent<Rigidbody>();
                    _temp.constraints = RigidbodyConstraints.FreezeAll;
                    Debug.Log("picked up");
                }

            }

            if (_inputDetector.OpenPressed)
            {
                if (!(_heldObj is null))
                {
                    DropObject();
                    _temp.constraints = RigidbodyConstraints.None;
                }
            }

            if (!(_heldObj is null))
            {
                MoveObject();
            }
        }

        private void MoveObject()
        {
            if (Vector3.Distance(_heldObj.transform.position, holdParent.position) > 0.1f)
            {
                var moveDirection = (holdParent.position - _heldObj.transform.position);
                _heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * MoveForce);
            }
        }

        private void PickupObject(GameObject pickObj)
        {
            if (pickObj.GetComponent<Rigidbody>())
            {
                var objBody = pickObj.GetComponent<Rigidbody>();
                objBody.drag = 10;

                objBody.transform.parent = holdParent;
                _heldObj = pickObj;
            }
        }

        private void DropObject()
        {
            var heldRig = _heldObj.GetComponent<Rigidbody>();
            heldRig.drag = 10;

            _heldObj.transform.parent = null;
            _heldObj = null;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Grabbable") || collision.gameObject.CompareTag("GrabbableFalse"))
            {
                canGrab = true;
                _body = collision.gameObject;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Grabbable") || collision.gameObject.CompareTag("GrabbableFalse"))
            {
                canGrab = false;
                _body = null;
            }
        }
    }
}
