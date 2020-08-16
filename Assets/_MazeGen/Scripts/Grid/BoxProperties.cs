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
        Debug.Log("visited");        
        switch (side)
        {
            case "n":
                wallN.SetActive(false);
                isVisited = true;
                //Debug.Log("wallN");
                break;
            case "s":
                wallS.SetActive(false);
                isVisited = true;
                //Debug.Log("wallS");
                break;
            case "w":
                wallW.SetActive(false);
                isVisited = true;
                //Debug.Log("wallW");
                break;
            case "e":
                wallE.SetActive(false);
                isVisited = true;
                //Debug.Log("wallE");
                break;
            default:
                break;
        }

        
    }

    public bool VisitCheck() //returns if it is visited or not
    {
        return isVisited;
    }

}
