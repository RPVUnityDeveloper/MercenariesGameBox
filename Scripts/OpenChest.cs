using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    private Image _image;
    private Button _button;

    [SerializeField] private NewItems _NewItems;

    [SerializeField] private float _TimeToOpening;
    private float _currentTime;

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _currentTime = _TimeToOpening;
    }

    private void TimeToOpening()
    {
        if (_currentTime > 0)
            _currentTime -= Time.deltaTime;

        _button.interactable = _currentTime<=0;
    }

    private void ImageUpdate()
    {
        float persent = 1-_currentTime / _TimeToOpening;

        _image.fillAmount = persent;
    }

    private void Update()
    {
        TimeToOpening();
        ImageUpdate();
    }

    public void Opening()
    {
        _currentTime = _TimeToOpening;
        _NewItems.IdentifyCell();
    }
}
