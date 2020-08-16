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

    private List<int> stack;
    private List<int> map;
    private List<BoxProperties> boxes;

    private int boxNumber;
    private int stackNumber;

    void Start()
    {
        map = new List<int>();
        stack = new List<int>();
        boxes = new List<BoxProperties>();

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
                boxes.Add(newBox.GetComponent<BoxProperties>());                
                map.Add(boxNumber);
                boxNumber++;
            }
        }
    }

    private void GenerateMaze()
    {
        boxes[0].VisitBox("w");
        stack.Add(0);

        for (int i = 0; i < 200 * boxNumber; i++)
        {
            SelectBox();
        }
    }

    private void SelectBox()
    {
        int dir = Random.Range(0,3);
        switch (dir)
        {
            case 0:

                stackNumber++;
                Debug.Log(boxes[stack.Count].VisitCheck() + " s");
                if (boxes[stack.Count] != null && !boxes[stack.Count].VisitCheck() && stack.Count < boxNumber - 1 )
                {
                    boxes[stack[stackNumber - 1]].VisitBox("s");                    
                    stack.Add(stackNumber);
                }
                else
                {
                    stackNumber--;
                }
                

                break;
            case 1:
                stackNumber++;
                Debug.Log(boxes[stack.Count].VisitCheck() + " n");
                if (boxes[stack.Count] != null && !boxes[stack.Count].VisitCheck() && stack.Count < boxNumber - 1)
                {
                    boxes[stack[stackNumber - 1]].VisitBox("n");
                    stack.Add(stackNumber);
                }
                else
                {
                    stackNumber--;
                }
                break;
            case 2:
                stackNumber++;
                Debug.Log(boxes[stack.Count].VisitCheck() + " w");
                if (boxes[stack.Count] != null && !boxes[stack.Count].VisitCheck() && stack.Count < boxNumber - 1)
                {
                    boxes[stack[stackNumber - 1]].VisitBox("w");
                    stack.Add(stackNumber);
                }
                else
                {
                    stackNumber--;
                }
                break;
            case 3:
                stackNumber++;
                Debug.Log(boxes[stack.Count].VisitCheck() + " e");
                if (boxes[stack.Count] != null && !boxes[stack.Count].VisitCheck() && stack.Count < boxNumber - 1)
                {
                    boxes[stack[stackNumber - 1]].VisitBox("e");
                    stack.Add(stackNumber);
                }
                else
                {
                    stackNumber--;
                }
                break;
            default:
                break;
        }
    }
}
