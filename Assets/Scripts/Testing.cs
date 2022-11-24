using UnityEngine;

public class Testing : MonoBehaviour
{
    public void InteractableBeingTouched()
    {
        Debug.Log("Interaction with "+this.gameObject.name);
    }

    public void HandTouchingThis()
    {
        Debug.Log("Hand "+this.gameObject.name+" is touching an interactable");
    }
}
