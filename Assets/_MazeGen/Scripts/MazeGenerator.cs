using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject box;
    private MazeGenerator mazeGen;                              

    public int row;
    public int collumn;

    [SerializeField] private float boxSpaceX = 4; //room between boxes
    [SerializeField] private float boxSpaceZ = 4; //room between boxes

    private Dictionary<int, BoxProperties> map;
    private List<int> stack;

    private int boxNumber;

    void Start()
    {
        map = new Dictionary<int, BoxProperties>();
        stack = new List<int>();

        mazeGen = GetComponent<MazeGenerator>();
        GenerateGrid();
        GenerateMaze();
    }

    private void GenerateGrid()//generates grid of boxes for every row and column
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < collumn; j++)
            {
                GameObject newBox = Instantiate(box, new Vector3(i * boxSpaceX, 0, j * boxSpaceZ), Quaternion.identity);
                map.Add(boxNumber, newBox.GetComponent<BoxProperties>());
                boxNumber++;
            }
        }
    }

    private void GenerateMaze()
    {
        map[0].VisitBox("w");
        stack.Add(0);
        SelectBox();
    }

    private void SelectBox()
    {
        int dir = Random.Range(0,3);
        switch (dir)
        {
            case 0:
                if (stack.Count < 0 && stack.Count > boxNumber)
                {
                    stack.Add(stack[stack.Count] + 1);
                    map[stack[stack.Count]].VisitBox("n");
                }
                //stack.Add(stack[stack.Count] + 1);
                break;
            case 1:
                if (stack.Count < 0 && stack.Count > boxNumber)
                {
                    stack.Add(stack[stack.Count] + collumn);
                    map[stack[stack.Count]].VisitBox("w");
                }
                //stack.Add(stack[stack.Count] + collumn);
                break;
            case 2:
                if (stack.Count < 0 && stack.Count > boxNumber)
                {
                    stack.Add(stack[stack.Count] - 1);
                    map[stack[stack.Count]].VisitBox("s");
                }
                //stack.Add(stack[stack.Count] - 1);
                break;
            case 3:
                if (stack.Count < 0 && stack.Count > boxNumber)
                {
                    stack.Add(stack[stack.Count] - collumn);
                    map[stack[stack.Count]].VisitBox("e");
                }
                //stack.Add(stack[stack.Count] - collumn);
                break;
            default:
                break;
        }
    }
}
