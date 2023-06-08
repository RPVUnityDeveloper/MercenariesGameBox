using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _Width = 9;
    [SerializeField] private int _Height = 7;

    [SerializeField] private Camera _Camera;

    [SerializeField] private GameObject CellPrefab;

    public List<List<Cell>> cells;

    private void Start()
    {
        float offsetX = _Camera.transform.position.x-16;
        float offsetY = _Camera.transform.position.y-8;

        cells = new List<List<Cell>>();

        for (int i = 0; i < _Width; i++)
        {
            cells.Add(new List<Cell>());

            for (int j = 0; j < _Height; j++)
            {
                GameObject obj = Instantiate(CellPrefab, new Vector3(i*2+offsetX, j*2+offsetY, 0), Quaternion.identity);
                Cell cell = obj.GetComponent<Cell>();
                cell.X = i;
                cell.Y = j;
                cell.IsAlive = false;
                cell.SetSprite();
                cells[i].Add(cell);
            }
        }

        for (int i = 0; i < _Width; i++)
        {
            cells[i][0].IsAlive = true;
            cells[i][0].SetSprite();
            cells[i][_Height - 1].IsAlive = true;
            cells[i][_Height - 1].SetSprite();
        }

        for (int j = 1; j < _Height-1; j++)
        {
            cells[0][j].IsAlive = true;
            cells[0][j].SetSprite();
            cells[_Width-1][j].IsAlive = true;
            cells[_Width-1][j].SetSprite();
        }
    }
}