using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridGen : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private MazeGenerator mazeGen;                               //outdated//[SerializeField] private GameObject mole;

    public int row;
    public int collumn;

    [SerializeField] private float boxSpaceX = 4; //room between boxes
    [SerializeField] private float boxSpaceZ = 4; //room between boxes

    private Dictionary<int, int> map;
    private List<GameObject> floors;

    void Start()
    {
        mazeGen = GetComponent<MazeGenerator>();
        floors = new List<GameObject>();
        GenerateGrid();
    }

    private void GenerateGrid()//generates grid of boxes for every row and column
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < collumn; j++)
            {
               GameObject newBox = Instantiate(box, new Vector3(i * boxSpaceX, 0, j * boxSpaceZ), Quaternion.identity);
               floors.Add(newBox.GetComponent<BoxProperties>().floor);
               
            }
        }

        for (int i = 0; i < floors.Count; i++)
        {
            floors[i].GetComponent<NavMeshSurface>().BuildNavMesh();
            floors[i].GetComponent<NavMeshModifier>().area = 3;
        }
                                                                        //outdated//mole.GetComponent<Mole>().SetDestination(floors[Random.Range(0,floors.Count)].transform);
    }
}
