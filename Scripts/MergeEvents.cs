using UnityEngine;

public class MergeEvents : MonoBehaviour
{
    public static void MergeItemsEvent(MergeItem item)
    {
        StatsEntity statsEntity = GlobalConst.HERO.GetComponent<StatsEntity>();
        Attack attack = GlobalConst.HERO.GetComponent<Attack>();

        MergeItemData _mergeItemData = GameManager.mergeItemList.GetItemData(item);

        if (_mergeItemData.itemType == MergeItemType.Food)
        {
            float value = 1 * (_mergeItemData.mergeLevel + 1);
            statsEntity.CurrentHealt += value;

            if (_mergeItemData.mergeLevel == 5)
                statsEntity.MaxHelth += 5;
        }

        if (_mergeItemData.itemType == MergeItemType.Weapon)
        {
            float value = statsEntity.AttackDamage * (_mergeItemData.mergeLevel + 1);
            attack.TakeDamage(value);

            if (_mergeItemData.mergeLevel == 5)
                statsEntity.AttackDamage += 1;
        }
    }
}
