using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsAlive { get; set; }
    public GameObject MergeObj { get; set; }

    [SerializeField] private Sprite _SpriteTrue;
    [SerializeField] private Vector3 _ScaleTrue;
    [SerializeField] private Sprite _SpriteFalse;
    [SerializeField] private Vector3 _ScaleFalse;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite()
    {
        if (IsAlive)
        {
            _renderer.sprite = _SpriteTrue;
            transform.localScale = _ScaleTrue;
        }
        else
        {
            _renderer.sprite = _SpriteFalse;
            transform.localScale = _ScaleFalse;
        }
    }
}
