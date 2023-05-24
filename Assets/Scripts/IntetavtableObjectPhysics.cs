using UnityEngine;

public class IntetavtableObjectPhysics : MonoBehaviour
{
    [SerializeField] protected Transform _defaultTarget;
    [SerializeField] private int strength;
    [SerializeField] private int damping;
    protected Transform _currentTarget;
    protected Rigidbody _rigidbody;
    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = _defaultTarget;
    }
    protected void FixedUpdate()
    {
        var positionDelta = _currentTarget.position - _rigidbody.position;
        var force = positionDelta * strength - _rigidbody.velocity * damping;
        _rigidbody.AddForce(force);

        transform.rotation = _currentTarget.rotation;

        //var rotationDifference = _currentTarget.rotation * Quaternion.Inverse(transform.rotation);
       // rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

       // var rotationDifferenceInDegree = angleDegree * rotationAxis;

        //_rigidbody.angularVelocity = rotationDifferenceInDegree / Time.fixedDeltaTime * Mathf.Deg2Rad;

    }
    // позициониравть руку в точке во время движения, и просчитывать физику в момент остановкки.
    // строить лучи и находить точки пересечения с объектами
}

