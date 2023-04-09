using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public enum Types
    {
        Rake = 1,
        Shovel = 2,
        Watering�an = 3,
    }
    public abstract Types Type { get; protected set; }
    [SerializeField] public int Power { get; protected set; }
    [SerializeField] protected GameObject Trigger;
    [SerializeField] protected GameObject Collider;
    public void ChangeState(bool isOnHand)
    {
        Collider.SetActive(false);
        Trigger.SetActive(false);
        if (isOnHand)
            Trigger.SetActive(true);
        else
            Collider.SetActive(true);
    }
}
