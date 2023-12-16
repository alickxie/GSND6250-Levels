using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Make this a instance
    public static GameManager instance;

    public bool outlineEnabled = true;

    public List<GameObject> players;

    public Animator kidAnimator;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    public QTETree qTETree;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Set the instance
        instance = this;
        // StopKidMoveing(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the game
            Application.Quit();
        }

        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     // Test the function
        //     NextPlayer();
        // }

        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //     // Test the function
        //     ending();
        // }
    }

    public void NextPlayer()
    {
        // Close the current open player in the list and open the next one
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
            {

                players[i].SetActive(false);

                if (i + 1 < players.Count)
                {
                    players[i + 1].SetActive(true);
                    // outlineEnabled = false;
                }
                else
                {
                    players[0].SetActive(true);
                    // outlineEnabled = true;
                }
                break;
            }
        }
    }

    public void StartQTETree()
    {
        qTETree.decorateTree();
    }

    public void StopKidMoveing(bool x)
    {
        playerMovement.Moveable(!x);
        mouseLook.LockCursor(x);
    }

    public void KidAvoid()
    {
        kidAnimator.enabled = true;
        StartCoroutine(KidAvoidCoroutine());
    }

    IEnumerator KidAvoidCoroutine()
    {
        yield return new WaitForSeconds(4f);
        kidAnimator.enabled = false;
        NextPlayer();
    }

    public void ending()
    {
        Debug.Log("ending");
        audioSource.Play();
        StartCoroutine(endingCoroutine());
    }

    IEnumerator endingCoroutine()
    {
        NextPlayer();
        yield return new WaitForSeconds(5f);
        NextPlayer();
        yield return new WaitForSeconds(5f);
        NextPlayer();
    }
}
