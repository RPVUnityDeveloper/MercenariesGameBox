using UnityEngine;

public class MergeObjectController : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector3 _startPosition;

    private Collider2D _collider2d;

    private string _maskMerge = "Mergeable";

    public MergeItem Item;
    public Cell Cell;
    private MergeItemData _mergeItemData;

    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        _mergeItemData = GameManager.mergeItemList.GetItemData(Item);
        _collider2d = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        _isDragging = true;
        _startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        Vector2 dropPosition = new Vector2(transform.position.x, transform.position.y);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(dropPosition, 0.1f, LayerMask.GetMask(_maskMerge));

        bool merged = false;

        foreach (Collider2D collider in colliders)
        {
            if (collider != _collider2d)
            {
                MergeObjectController mergeObject = collider.GetComponent<MergeObjectController>();

                if (mergeObject != null)
                {
                    MergeItemData mergeItemDataTarget = GameManager.mergeItemList.GetItemData(mergeObject.Item);

                    if (mergeItemDataTarget != null && mergeItemDataTarget.mergeLevel == _mergeItemData.mergeLevel)
                    {
                        merged = true;
                        mergeObject.Merge(this);
                        break;
                    }
                }
            }
        }

        if (!merged && transform.position != _startPosition)
            transform.position = _startPosition;
    }

    public void Merge(MergeObjectController otherObject)
    {
        MergeItem newItem = MergeItem.ItemFood1;

        /*if (_mergeItemData.itemType == MergeItemType.Armor)
        {
            newItem = (MergeItem)(int)Item + 1;

            if (newItem > MergeItem.ItemArmor6)
            {
                newItem = MergeItem.ItemArmor1;
            }
        }
        else */
        if (_mergeItemData.itemType == MergeItemType.Food)
        {
            newItem = (MergeItem)(int)Item + 1;

            if (newItem > MergeItem.ItemFood6)
            {
                newItem = MergeItem.ItemFood1;
                Debug.Log("Final");
            }
        }
        else if (_mergeItemData.itemType == MergeItemType.Weapon)
        {
            newItem = (MergeItem)(int)Item + 1;

            if (newItem > MergeItem.ItemWeapon6)
            {
                newItem = MergeItem.ItemWeapon1;
                Debug.Log("Final");
            }
        }

        GameObject mergedObject = Instantiate(_prefab);
        mergedObject.transform.position = transform.position;
        mergedObject.GetComponent<MergeObjectController>().Initialize(newItem, Cell);

        Destroy(gameObject);
        Destroy(otherObject.gameObject);
    }

    private void Initialize(MergeItem newItem, Cell newCell)
    {
        Item = newItem;
        Cell = newCell;
        Cell.MergeObj = gameObject;

        gameObject.GetComponent<MergeObjectController>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.mergeItemList.GetItemData(Item).itemSprite;

        MergeEvents.MergeItemsEvent(Item);
    }

}