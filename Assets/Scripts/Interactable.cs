using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(GameObject iInstigator);

    public abstract string GetInteractMessage();

    public abstract bool CanInteract();

    public abstract void ActivateInteractable();
}
