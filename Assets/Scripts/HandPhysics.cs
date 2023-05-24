using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    [SerializeField] private Transform _virtualHand;
    [SerializeField] private PlayerController controller;

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
            var force = positionDelta * 5000 - _rigidbody.velocity * 50;
            _rigidbody.AddForce(force);

            var rotationDifference = _currentTarget.rotation * Quaternion.Inverse(transform.rotation);
            rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

            var rotationDifferenceInDegree = angleDegree * rotationAxis;

            _rigidbody.angularVelocity = rotationDifferenceInDegree / Time.fixedDeltaTime * Mathf.Deg2Rad;
        }
    }

    private void Update()
    {
        if (_isMoveWithStick)
        {
            Vector3 position;
            var rayStart = Camera.main.transform.position;
            rayStart.y -= 0.2f;
            RaycastHit hit;
            bool rayDidHit = Physics.Raycast(rayStart, Camera.main.transform.forward, out hit, (_virtualHand.position - rayStart).magnitude);
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
