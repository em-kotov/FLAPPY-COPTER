using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _parallaxEffect;

    private float _startPosition;
    private float _length;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _startPosition = transform.position.x;
        _length = _renderer.bounds.size.x;
    }

    private void Update()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosition + dist,
                                    transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
            _startPosition += _length;
        else if (temp < _startPosition - _length)
            _startPosition -= _length;
    }
}
