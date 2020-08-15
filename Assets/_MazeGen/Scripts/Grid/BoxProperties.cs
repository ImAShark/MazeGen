using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProperties : MonoBehaviour
{
    //private enum sides {North,South,West,East}

    [SerializeField] private GameObject wallN;
    [SerializeField] private GameObject wallW;
    [SerializeField] private GameObject wallS;
    [SerializeField] private GameObject wallE;
    public GameObject floor;

    private bool isVisited = false;


    //make function to reset trough delecate (Action)

    public void VisitBox(string side)//lets function know from which side the box was entered, and removes the wall accordingly. Then sets it to visited.
    {
        switch (side)
        {
            case "n":
                wallN.SetActive(false);
                break;
            case "s":
                wallS.SetActive(false);
                break;
            case "w":
                wallW.SetActive(false);
                break;
            case "e":
                wallE.SetActive(false);
                break;
            default:
                break;
        }

        isVisited = true;
    }

}
