using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    [SerializeField] private Transform _virtualHand;
    [SerializeField] private PlayerController controller;
    [SerializeField] private float _maxRotationChange;

    protected Transform _currentTarget;
    protected Rigidbody _rigidbody;
    bool _isMoveWithStick => controller.IsMoveWithStick;
    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = _virtualHand;
    }
    protected void FixedUpdate()
    {
        if (!_isMoveWithStick)
        {
            var positionDelta = _currentTarget.position - _rigidbody.position;
            var force = positionDelta * 3200 - _rigidbody.velocity * 120;
            _rigidbody.AddForce(force);

            var rotationDifference = _currentTarget.rotation * Quaternion.Inverse(_rigidbody.rotation);
            rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

            if (angleDegree > 180)
                angleDegree -= 360;

            var rotationDifferenceInDegree = angleDegree * rotationAxis;

            var angularVelocity = rotationDifferenceInDegree / Time.fixedDeltaTime * Mathf.Deg2Rad;
            if (!float.IsNaN(angularVelocity.x) && !float.IsInfinity(angularVelocity.x))
            {

                _rigidbody.angularVelocity = angularVelocity;
            }
        }
    }

    private void Update()
    {
        if (_isMoveWithStick)
        {
            LayerMask rayMask = LayerMask.GetMask("Default", "GroundBlock");
            Vector3 position;
            var rayStart = Camera.main.transform.position;
            rayStart.y -= 0.2f;
            RaycastHit hit;
            bool rayDidHit = Physics.Raycast(rayStart, Camera.main.transform.forward, out hit, (_virtualHand.position - rayStart).magnitude, rayMask);
            Debug.DrawRay(rayStart, Camera.main.transform.forward, Color.green);
            if (rayDidHit)
                position = hit.point;
            else
                position = _virtualHand.position;
            transform.position = position;
            transform.rotation = _virtualHand.rotation;
        }
    }
}
