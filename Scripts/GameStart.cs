using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private float _Chanse;

    [SerializeField] private Field _Field;

    public List<MergeItem> _ListStartItem = new List<MergeItem>();

    [SerializeField] private GameObject _Prefab;

    [SerializeField] private Camera _Camera;

    private void Start()
    {
        float offsetX = _Camera.transform.position.x - 16;
        float offsetY = _Camera.transform.position.y - 8;

        List<List<Cell>> cells = _Field.cells;
        int width = cells.Count;
        int height = cells[0].Count;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell cell = cells[i][j];

                int rnd = Random.Range(0, 100);

                if (rnd<=_Chanse)
                {
                    if (!cell.IsAlive && cell.MergeObj==null)
                    {
                        GameObject obj = Instantiate(_Prefab, new Vector3(cell.X*2+offsetX, cell.Y*2+offsetY, 0), Quaternion.identity);

                        MergeItem item = obj.GetComponent<MergeObjectController>().Item;
                        item = _ListStartItem[Random.Range(0, _ListStartItem.Count)];
                        obj.GetComponent<MergeObjectController>().Item = item;

                        obj.GetComponent<MergeObjectController>().Cell = cell;

                        obj.GetComponent<SpriteRenderer>().sprite = GameManager.mergeItemList.GetItemData(item).itemSprite;

                        cell.MergeObj = obj;
                    }
                }
            }
        }
    }
}
