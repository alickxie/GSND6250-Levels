using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoggleOpen : MonoBehaviour
{
    public GameObject goggle;
    public GameObject OldLences;
    public GameObject PartOldLences;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if Player press TAB, open or close the goggle
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (goggle.activeSelf)
            {
                goggle.SetActive(false);
                OldLences.SetActive(true);
                PartOldLences.SetActive(false);
            }
            else
            {
                goggle.SetActive(true);
                OldLences.SetActive(false);
                PartOldLences.SetActive(true);
            }
        }
    }
}
