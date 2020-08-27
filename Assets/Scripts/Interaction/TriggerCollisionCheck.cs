using UnityEngine;

public class TriggerCollisionCheck : MonoBehaviour
{
    private PlayerInput playerInput;
    private IObjectInteraction objectInteraction;
    bool changeSignal;

    [SerializeField]
    protected float interactionDistance;

    private void Start()
    {
        objectInteraction = GetComponent<IObjectInteraction>();
        changeSignal = false;
    }

    private void OnTriggerEnter(Collider colliPlayer)
    {
        playerInput = colliPlayer.GetComponent<PlayerInput>();
        objectInteraction.Signal();
        changeSignal = false;
    }

    private void OnTriggerStay(Collider colliPlayer)
    {
        // 상호작용이 가능하지 않은 거리
        if ((transform.position - colliPlayer.transform.position).magnitude > interactionDistance)
        {
            if (changeSignal)
            {
                objectInteraction.SignalChangeBack();
                changeSignal = false;
            }
                
            return;
        }
        
        // 상호작용이 가능한 거리
        if (!changeSignal)
        {
            changeSignal = true;
            objectInteraction.SignalChange();
        }

        if (playerInput.interact != 0f)
        {
            GetComponent<IObjectInteraction>().Interact();
            colliPlayer.GetComponent<IPlayerInteraction>().Interact();
        }
    }

    private void OnTriggerExit(Collider colliPlayer)
    {
        GetComponent<IObjectInteraction>().SignalEnd();
    }
}
