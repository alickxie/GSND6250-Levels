using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLength;
    private Camera _camera;
    
    private NoteController _noteController;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    //add
    [Header("Holding Position")]
    [SerializeField] private Transform HoldingPosition;
    [SerializeField] private LayerMask PickupMask;
    private Rigidbody CurrentObject;
    private int _pickupController;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f)),transform.forward, out RaycastHit hit, rayLength))
        {
            int pickupableItem = hit.collider.gameObject.layer;
            //Debug.Log(pickupableItem);
            if(pickupableItem == 18)
            {
                _pickupController = pickupableItem;
                HeighlightCrosshair(true);
            }
            else
            {
                ClearPickup();
            }


            var readableItem = hit.collider.GetComponent<NoteController>();
            //Debug.Log(readableItem);
            if (readableItem != null)
            {
                _noteController = readableItem;
                HeighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
            ClearPickup();
        }
        if (_noteController != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                _noteController.ShowNote();
            }
        }
        if(_pickupController == 18)
        {
            if (Input.GetKeyDown(interactKey))
            {
                if (CurrentObject)
                {
                    CurrentObject.useGravity = true;
                    CurrentObject = null;
                    return;
                }
                CurrentObject = hit.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
        //add

        /*
        if (Input.GetKeyDown(interactKey))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }
            if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hitInfo, rayLength, PickupMask))
            {
                CurrentObject = hitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }*/

    }

    void ClearNote()
    {
        if (_noteController != null)
        {
            HeighlightCrosshair(false);
            _noteController = null;
        }
    }
    void ClearPickup()
    {
        if(_pickupController == 18 )
        {
            HeighlightCrosshair(false);
            _pickupController = 0;
        }
    }

    void HeighlightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }

    //add
    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = HoldingPosition.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 20f * DistanceToPoint;
        }
    }
}
