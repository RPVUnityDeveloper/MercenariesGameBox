using System.Collections.Generic;
using UnityEngine;

public class NewItems : MonoBehaviour
{
    [SerializeField] private Field _Field;
    private List<List<Cell>> cells;

    [SerializeField] GameStart _GameStart;

    private List<MergeItem> _ListStartItem;

    [SerializeField] GameObject _Prefab;
    private void Start()
    {
        _ListStartItem = _GameStart._ListStartItem;
    }

    [SerializeField] private Camera _Camera;

    public void IdentifyCell()
    {
        float offsetX = _Camera.transform.position.x - 16;
        float offsetY = _Camera.transform.position.y - 8;

        cells = _Field.cells;
        int width = cells.Count;
        int height = cells[0].Count;

        bool isDone = false;

        for (int i = 0; i < width && !isDone; i++)
        {
            for (int j = 0; j < height && !isDone; j++)
            {
                int rndWidth = Random.Range(0, width);
                int rndHeight = Random.Range(0, height);

                Cell cell = cells[rndWidth][rndHeight];

                if (!cell.IsAlive && cell.MergeObj == null)
                {
                    Vector3 position = new Vector3(cell.X * 2+offsetX, cell.Y * 2+offsetY, 0);

                    GameObject obj = Instantiate(_Prefab, position, Quaternion.identity);

                    MergeItem item = obj.GetComponent<MergeObjectController>().Item;
                    item = _ListStartItem[Random.Range(0, _ListStartItem.Count)];
                    obj.GetComponent<MergeObjectController>().Item = item;

                    obj.GetComponent<MergeObjectController>().Cell = cell;

                    obj.GetComponent<SpriteRenderer>().sprite = GameManager.mergeItemList.GetItemData(item).itemSprite;

                    cell.MergeObj = obj;

                    isDone = true;
                }
            }
        }
    }
}
