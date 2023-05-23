using UnityEngine;

public class InteractableObjectPhysics : MonoBehaviour
{
    [SerializeField] protected Transform _defaultTarget;
    [SerializeField] private int strength;
    [SerializeField] private int damping;
    [SerializeField] private PlayerController _player;
    private HandGrabInteractable _twoHandGrabInteractable;
    protected Transform _currentTarget;
    protected Rigidbody _rigidbody; 
    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = _defaultTarget;
        _twoHandGrabInteractable = _defaultTarget.GetComponent<HandGrabInteractable>();
    }
    protected void FixedUpdate()
    {
        if (_twoHandGrabInteractable.isSelected)
        {
            _rigidbody.useGravity = false;
            var positionDelta = _currentTarget.position - _rigidbody.position;
            var force = positionDelta * strength - _rigidbody.velocity * damping;
            _rigidbody.AddForce(force);

            transform.rotation = _currentTarget.rotation;

            var rotationDifference = _currentTarget.rotation * Quaternion.Inverse(transform.rotation);
            rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

            if (angleDegree > 180)
                angleDegree -= 360;
            var rotationDifferenceInDegree = angleDegree * rotationAxis;

            _rigidbody.angularVelocity = rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime;
        }
        else
        {
            _rigidbody.useGravity = true;
        }
    }
    public void Selected()
    {
        var spawnPosition = _player.transform.position + Camera.main.transform.forward;
        spawnPosition.y = _player.transform.position.y;
        transform.position = spawnPosition;
    }
}

