using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private StatsEntity _EnemyStats;
    private StatsEntity _heroStats;

    [SerializeField] private bool _IsEnemy = false;

    [SerializeField] private float _TimeToAttackEnemy = 5;
    private float _currentTime = 0;

    private AnimationController _animationController;

    private void Start()
    {
        _animationController = GetComponent<AnimationController>();
        _heroStats = GetComponent<StatsEntity>();
    }

    public void TakeDamage(float damage)
    {
        if (!_heroStats.IsDeath)
        {
            if (damage>0)
            {
                _animationController.AttackAnimation();
                _EnemyStats.CurrentHealt -= damage;
            }
        }
    }

    private void Update()
    {
        if (_IsEnemy)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _TimeToAttackEnemy)
            {
                _currentTime = 0;
                TakeDamage(GetComponent<StatsEntity>().AttackDamage);
            }
        }
    }
}
