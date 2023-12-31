using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnTree : MonoBehaviour
{
    public GameObject decorationOnTree;
    public GameObject decorationOnHand;
    [SerializeField] private string treeitemName;

    public void CompareItems()
    {
        // get first child of decorationOnTree
        if (decorationOnHand.transform.childCount > 0)
        {
            // Debug.Log("Child count: " + decorationOnHand.transform.childCount);
            GameObject child = decorationOnHand.transform.GetChild(0).gameObject;
            if (treeitemName == child.GetComponent<HoldInHand>().GetItemName())
            {
                if (treeitemName == "bigcane")
                {
                    GameManager.instance.StartQTETree();
                    GameManager.instance.StopKidMoveing(true);
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(child);
                    decorationOnTree.SetActive(true);
                    Destroy(this.gameObject);
                }
                // Debug.Log("Same item");
                // Destroy the child
            }
        }
    }
}
