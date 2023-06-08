using UnityEngine;

public class StatsEntity : MonoBehaviour
{
    public Animator Animator;

    [SerializeField] private float _MaxHelth;
    public float MaxHelth
    {
        get { return _MaxHelth; }
        set
        {
            float persent = _currentHealt / _MaxHelth;
            _MaxHelth = value;
            _currentHealt = _MaxHelth / persent;
        }
    }

[SerializeField] private float _AttackDamage;
    public float AttackDamage 
    {
        get { return _AttackDamage; }
        set
        {
            if (value < 0)
                value = 0;

            _AttackDamage = value;
        } 
    }

    private float _currentHealt;
    public float CurrentHealt
    {
        get { return _currentHealt; }
        set
        {
            if (value < 0)
                value = 0;

            if (value > MaxHelth)
                value = MaxHelth;

            _currentHealt = value;
        }
    }

    public bool IsDeath { get; set; }

    private void DeathEntity()
    {
        if (!IsDeath)
        {
            IsDeath = true;
            GetComponent<AnimationController>().DeathAnimation();
        }
    }

    private void Start()
    {
        MaxHelth = _MaxHelth;
        CurrentHealt = MaxHelth;
        IsDeath = false;
    }

    private void Update()
    {
        if (CurrentHealt <= 0)
            DeathEntity();
    }
}
