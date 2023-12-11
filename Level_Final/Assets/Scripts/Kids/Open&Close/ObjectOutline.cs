using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOutline : MonoBehaviour
{
    private Transform highlight;
    private RaycastHit raycastHit;
    public GameObject dotCursor;
    public GameObject selectCursor;

    public GameObject holdingPosition;

    void Update()
    {
        // Reset the previous highlight
        if (highlight != null)
        {
            var outline = highlight.gameObject.GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false;
            }
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;

            if (highlight.CompareTag("Selectable"))
            {
                HandleHighlight();

                if (Input.GetMouseButtonDown(0))
                {
                    AudioSource audioSource = highlight.gameObject.GetComponent<AudioSource>();
                    // DrawerAct drawerAct = highlight.gameObject.GetComponent<DrawerAct>();
                    OpenBox openBox = highlight.gameObject.GetComponent<OpenBox>();

                    if (audioSource != null)
                    {
                        HandleMusicPlayer();
                    }
                    else if (openBox != null)
                    {
                        HandleSlideDrawerAction();
                    }

                    if (highlight.gameObject.GetComponent<DiaryAct>() != null)
                    {
                        highlight.gameObject.GetComponent<DiaryAct>().DiaryAction();
                    }

                    if (highlight.gameObject.GetComponent<PenOut>() != null)
                    {
                        HandleMessyAction();
                    }

                    if (highlight.gameObject.GetComponent<HoldInHand>() != null)
                    {
                        highlight.gameObject.GetComponent<HoldInHand>().CheckHoldingPosition(holdingPosition);
                    }

                    if (highlight.gameObject.GetComponent<CheckOnTree>() != null)
                    {
                        Debug.Log("Compare items");
                        highlight.gameObject.GetComponent<CheckOnTree>().CompareItems();
                    }

                    if (highlight.gameObject.GetComponent<OpenDoor>() != null)
                    {
                        highlight.gameObject.GetComponent<OpenDoor>().OnMouseDown();
                    }
                }
            }
            else
            {
                ResetCursor();
            }
        }
        else
        {
            ResetCursor();
        }
    }

    void HandleHighlight()
    {
        selectCursor.SetActive(true);
        dotCursor.SetActive(false);

        var outline = highlight.gameObject.GetComponent<Outline>();
        if (outline == null)
        {
            outline = highlight.gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.magenta;
            outline.OutlineWidth = 1000.0f;
        }
        outline.enabled = true;
    }

    void HandleMusicPlayer()
    {
        AudioSource audioSource = highlight.gameObject.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    void HandleDrawerAction()
    {
        var drawerAct = highlight.gameObject.GetComponent<DrawerAct>();
        if (drawerAct != null)
        {
            drawerAct.DrawerAction();
        }
    }

    void HandleSlideDrawerAction()
    {
        var slideDrawerAct = highlight.gameObject.GetComponent<OpenBox>();
        if (slideDrawerAct != null)
        {
            slideDrawerAct.OnMouseDown();
        }
    }

    void HandleMessyAction()
    {
        var messyAct = highlight.gameObject.GetComponent<PenOut>();
        if (messyAct != null)
        {
            messyAct.GetOut();
        }
    }

    void ResetCursor()
    {
        selectCursor.SetActive(false);
        dotCursor.SetActive(true);
    }
}
