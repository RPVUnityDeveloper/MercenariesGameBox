using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [SerializeField] private Image _XPBar;
    [SerializeField] private Text _textXPBar;

    private StatsEntity _statsEntity;

    private void Start()
    {
        _statsEntity = GetComponent<StatsEntity>();
    }

    private void Update()
    {
        float persent = _statsEntity.CurrentHealt / _statsEntity.MaxHelth;
        _XPBar.fillAmount = persent;

        _textXPBar.text = $"{_statsEntity.CurrentHealt}/{_statsEntity.MaxHelth}";
    }
}
