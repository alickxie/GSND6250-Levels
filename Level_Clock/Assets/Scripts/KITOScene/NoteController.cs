using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
//using UnityStandarAssets.Characters.FirstPerson;

public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    //[SerializeField] private FirstPersonController player;
    public PlayerMovement player; // Reference to your custom player movement script.

    [Header("UI Text")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [Space(10)]
    [SerializeField][TextArea] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent; // Create and set up this Unity Event in the Inspector.
    public bool isOpen = false;


    public void ShowNote()
    {

        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        DisablePlayer(true);
        isOpen = true;

    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);
        //noteTextAreaUI.text = null;
        DisablePlayer(false);
        isOpen = false;
    }

    void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
        MouseLook.instance.LockCursor(disable);
    }

    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(closeKey))
            {
                Invoke("DisableNote",0.1f);
            }
        }
    }

}
