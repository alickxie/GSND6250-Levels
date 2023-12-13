using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Make this a instance
    public static GameManager instance;

    public bool outlineEnabled = true;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        // Set the instance
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Test the function
            NextPlayer();
        }
    }

    public void NextPlayer()
    {
        // Close the current open player in the list and open the next one
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {
                if (i == 0)
                {
                    outlineEnabled = true;
                }
                else
                {
                    outlineEnabled = false;
                }   

                players[i].SetActive(false);

                if (i + 1 < players.Count)
                {
                    players[i + 1].SetActive(true);
                }
                else
                {
                    players[0].SetActive(true);
                }
                break;
            }
        }

    }
}
