using UnityEngine;

public class ZoneSwitcher : MonoBehaviour
{
    [SerializeField] private float _offset = 38.4f;

    private ZoneController _lastZoneController;

    public void SwitchToNext(ZoneController zoneController)
    {
        _lastZoneController = zoneController;
        zoneController.SetBackgroundPosition(_offset);
        zoneController.SpawnStars();
    }

    public void ResetZone()
    {
        if (_lastZoneController != null)
            _lastZoneController.Reset();
    }
}
