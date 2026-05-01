using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public bool canInteract = false;
    [SerializeField] StairInteract stairInteract;
    [SerializeField] NPC npc;
    [SerializeField] NPC npc2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (canInteract)
            {
                Debug.Log("Player has interacted");
                if (stairInteract != null)
                {
                    stairInteract.Interaction();
                }
                if (npc != null)
                {
                    
                    npc.conversation();
                }
                if (npc2 != null)
                {
                    
                    npc2.conversation();
                }
            }
        }
    }
    


}
