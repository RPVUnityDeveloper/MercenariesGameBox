using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static MergeItemList mergeItemList;
    [SerializeField] private ItemData _ItemData;

    void Awake()
    {
        mergeItemList = new MergeItemList(/*_ItemData._ListSpriteArmor,*/ _ItemData._ListSpriteFood,_ItemData._ListSpriteWeapon);
    }

    public static string ANIMATION_DEATH = "DEATH";
    public static string ANIMATION_ATTACK = "ATTACK";
}
