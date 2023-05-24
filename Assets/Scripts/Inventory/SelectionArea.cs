using UnityEngine;
public class SelectionArea : MonoBehaviour
{
    [SerializeField] public int[] ZoneNumbers;
    [SerializeField] private GameObject selectobleObject;
    public void Choosed()
    {
        if (selectobleObject != null)
        {
            Inventory nextInventory;
            if (selectobleObject.TryGetComponent(out nextInventory))
            {
                nextInventory.gameObject.SetActive(true);
            }
            else if (selectobleObject != null)
            {

            }
        }
    }
}
