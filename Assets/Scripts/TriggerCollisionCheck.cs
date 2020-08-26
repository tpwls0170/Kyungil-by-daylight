using UnityEngine;

public class TriggerCollisionCheck : MonoBehaviour
{
    private void OnTriggerStay(Collider player)
    {
        GetComponent<IInteraction>().Interact();
        player.GetComponent<IInteraction>().Interact();
    }
}
