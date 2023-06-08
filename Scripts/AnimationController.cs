using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<StatsEntity>().Animator;
    }

    public void DeathAnimation()
    {
        _animator.Play(GameManager.ANIMATION_DEATH);
    }

    public void AttackAnimation()
    {
        _animator.Play(GameManager.ANIMATION_ATTACK);
    }
}
