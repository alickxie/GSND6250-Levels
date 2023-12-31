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
                    DrawerAct drawerAct = highlight.gameObject.GetComponent<DrawerAct>();

                    if (audioSource != null)
                    {
                        HandleMusicPlayer();
                    }
                    else if (drawerAct != null)
                    {
                        HandleDrawerAction();
                    }

                    if (highlight.gameObject.GetComponent<DiaryAct>() != null)
                    {
                        highlight.gameObject.GetComponent<DiaryAct>().DiaryAction();
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

    void ResetCursor()
    {
        selectCursor.SetActive(false);
        dotCursor.SetActive(true);
    }
}
