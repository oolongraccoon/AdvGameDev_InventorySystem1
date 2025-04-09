using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;   // Item to put in the inventory on pickup

    // When the player interacts with the item
    public override void Interact()
    {
        Debug.Log("Interact called on " + gameObject.name);
        base.Interact();

        PickUp();   // Pick it up!
    }

    // Pick up the item
    void PickUp()
    {
        Debug.Log("PickUp() was called");

        if (item == null)
        {
            Debug.LogWarning("Item is null!");
            return;
        }

        Debug.Log("Picking up " + item.name);

        if (Inventory.instance == null)
        {
            Debug.LogError("Inventory instance is missing!");
            return;
        }

        bool wasPickedUp = Inventory.instance.Add(item);    // Add to inventory
        Debug.Log("Item was picked up: " + wasPickedUp);

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);    // Destroy item from scene
    }
}
