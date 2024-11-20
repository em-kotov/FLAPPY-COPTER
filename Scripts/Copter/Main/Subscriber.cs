using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CollisionRegister _collisionRegister;
    [SerializeField] private Mover _mover;
    [SerializeField] private Copter _copter;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryDisplay _inventoryDisplay;
    [SerializeField] private ZoneSwitcher _zoneSwitcher;

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += _mover.Jump;

        _collisionRegister.PipeFound += _copter.OnPipeFound;
        _collisionRegister.StarFound += _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound += _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged += _inventoryDisplay.DisplayStarCount;

        _copter.GameOver += _inventory.Reset;
        _copter.GameOver += _mover.Reset;
        _copter.GameOver += _zoneSwitcher.ResetZone;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= _mover.Jump;
        
        _collisionRegister.PipeFound -= _copter.OnPipeFound;
        _collisionRegister.StarFound -= _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound -= _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged -= _inventoryDisplay.DisplayStarCount;

        _copter.GameOver -= _inventory.Reset;
        _copter.GameOver -= _mover.Reset;
        _copter.GameOver -= _zoneSwitcher.ResetZone;
    }
}
