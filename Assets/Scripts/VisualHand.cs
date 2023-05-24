using UnityEngine;

public class VisualHand : MonoBehaviour
{
    [SerializeField] private Transform _physicsHand;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotationSpeed;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_physicsHand.position,Time.deltaTime * _speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _physicsHand.rotation,Time.deltaTime * _rotationSpeed);
    }
}
