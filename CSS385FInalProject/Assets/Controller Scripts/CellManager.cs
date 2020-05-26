using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField]
    private int kMAX_TARGET_REJECTIONS = 10;
    private int numberOfCellsInfected = 0;

    // Start is called before the first frame update
    void Start()
    {

    }


    public GameObject GetRandomCell()
    {
        return transform.GetChild(Random.Range(0, transform.childCount)).gameObject;
    }


    // returns the closest of kMAX_TARGET_REJECTIONS randomly chosen cells. Will try to return an uninfected cell. If there are no uninfected cells, returns a random cell.
    public GameObject GetRandomCloseCell(Transform transform)
    {
        if (numberOfCellsInfected == this.transform.childCount)
        {
            return this.transform.GetChild(Random.Range(0, this.transform.childCount)).gameObject;
        }

        int counter = 1;
        Transform bestSoFar = this.transform.GetChild(Random.Range(0, this.transform.childCount - numberOfCellsInfected));
        float bestSoFarDistance = Vector3.Distance(bestSoFar.transform.position, transform.position);
        while (counter < kMAX_TARGET_REJECTIONS)
        {
            Transform nextConsideration = this.transform.GetChild(Random.Range(0, this.transform.childCount - numberOfCellsInfected));

            if (Vector3.Distance(nextConsideration.position, transform.position) < bestSoFarDistance)
            {
                bestSoFar = nextConsideration;
                bestSoFarDistance = Vector3.Distance(bestSoFar.transform.position, transform.position);
            }

            counter++;
        }
        return bestSoFar.gameObject;
    }

    public void notifyOfInfectionChange(CellBehavior cell)
    {
        if (cell.IsInfected())
        {
            cell.transform.SetAsLastSibling();
            numberOfCellsInfected++;
        }
        else
        {
            cell.transform.SetAsFirstSibling();
            numberOfCellsInfected--;
        }
    }

    public int GetNumberOfCellsInfected()
    {
        return numberOfCellsInfected;
    }
}
