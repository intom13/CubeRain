using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Color _secondColor;

    private Color _defaultColor = Color.white;
    
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = _defaultColor;
    }

    public void ChangeColor()
    {
        _renderer.material.color = _secondColor;
    }
}
