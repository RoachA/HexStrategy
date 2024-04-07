using UnityEngine;
using UniRx;
using Zenject;

public class InteractionManager : MonoBehaviour
{
    [Inject] private readonly SignalBus _bus;
    private ReactiveProperty<HexData> _selectedHex = new ReactiveProperty<HexData>();
    public IReadOnlyReactiveProperty<HexData> SelectedHex => _selectedHex;
    
    private ReactiveProperty<HexData> _targetedHex = new ReactiveProperty<HexData>();
    public IReadOnlyReactiveProperty<HexData> TargetedHex => _targetedHex;
    
    private void Start()
    {
        _bus.Subscribe<CoreSignals.HexSelectedSignal>(OnHexSelected);
        _bus.Subscribe<CoreSignals.HexTargetedSignal>(OnHexTargeted);
    }

    private void OnHexSelected(CoreSignals.HexSelectedSignal signal)
    {
        _selectedHex.Value = signal.SelectedHex;
    }

    private void OnHexTargeted(CoreSignals.HexTargetedSignal signal)
    {
        _targetedHex.Value = signal.TargetedHex;
    }
}
