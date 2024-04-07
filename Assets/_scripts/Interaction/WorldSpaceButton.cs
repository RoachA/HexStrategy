using System;
using UnityEngine;

public class WorldSpaceButton : MonoBehaviour
{
    private IInteractable _interactableTarget;

    private void Start()
    {
        _interactableTarget = GetComponent<IInteractable>();
    }

    public Type GetInteractableType()
    {
        Type targetType = default;
        
        if (_interactableTarget != null)
        {
            targetType = _interactableTarget.GetType();
        }

        return targetType;
    }

    public void OnHover()
    {
        if (_interactableTarget != null) _interactableTarget.OnInFocus();
    }

    public void OnSelect()
    {
        Debug.Log(gameObject.name);
        if (_interactableTarget != null) _interactableTarget.OnSelected();
    }
}
