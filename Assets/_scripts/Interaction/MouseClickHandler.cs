using UnityEngine;
using UniRx;
using Zenject;

public class MouseClickHandler : MonoBehaviour
{
    [Inject] private readonly InteractionManager _interactionManager;
    [Inject] private readonly SignalBus _bus;

    private WorldSpaceButton _itemOnFocus;
    private Camera _gameCam;
    
    private void Start()
    {
        _gameCam = GetComponentInChildren<Camera>();

        _interactionManager.SelectedHex.Subscribe(_ =>
        {
            /*if (_itemOnFocus != null && hex.)
            {
                OnHoverOverNewHex();
            }*/
        });
    }

    private void OnHoverOverNewHex()
    {
        
    }

    private void OnSelectHex()
    {
        
    }
    
    void Update()
    {
        Ray ray = _gameCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (!Physics.Raycast(ray, out hit)) return;
        WorldSpaceButton selectable = hit.collider.GetComponent<WorldSpaceButton>();
        selectable.OnHover();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (selectable != null)
            {
               // if (selectable.GetInteractableType() == typeof(HexView))
            }
        }
    }
}
