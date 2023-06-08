using UnityEngine;

public class GlobalConst : MonoBehaviour
{
    public static GameObject HERO;

    private void Awake()
    {
        HERO = gameObject;
    }
}
