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

    //add hold gear
    [Header("Holding Position")]
    [SerializeField] private Transform HoldingPosition;
    [SerializeField] private LayerMask PickupMask;
    private Rigidbody CurrentObject;
    private int _pickupController;

    //add globe
    private string _globeController;

    //add any goggle reference here
    private string _goggleController;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
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

            int pickupableItem = hit.collider.gameObject.layer;
            //Debug.Log(pickupableItem);
            if (pickupableItem == 18)
            {
                _pickupController = pickupableItem;
                HeighlightCrosshair(true);
            }
            else
            {
                ClearPickup();
            }

            var globeItem = hit.collider.gameObject.name;
            //Debug.Log(globeItem);
            if (globeItem == "UpperHolder")
            {
                _globeController = globeItem;
                HeighlightCrosshair(true);
            }
            else
            {
                ClearGlobe();
            }

            //add goggle part
            var goggleItem = hit.collider.gameObject.name;
            if (goggleItem == "goggle")
            {
                _globeController = goggleItem;
                HeighlightCrosshair(true);
            }
            else
            {
                ClearGoggle();
            }

        }
        else
        {
            ClearNote();
            ClearPickup();
            ClearGlobe();
        }
        if (_noteController != null)
        {
            bool noteIsOpen = _noteController.isOpen;
            Debug.Log(noteIsOpen);
            if (Input.GetKeyDown(interactKey) && !noteIsOpen)
            {
                _noteController.ShowNote();
            }
        }
        if (_pickupController == 18)
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
        if (_globeController == "UpperHolder")
        {
            if (Input.GetKeyDown(interactKey))
            {
                GlobeRotation globeRotation = hit.collider.gameObject.GetComponent<GlobeRotation>();
                if (globeRotation != null)
                {
                    // Call the RotateUpperHolder method
                    globeRotation.RotateUpperHolder();
                    //disable collider here
                }
            }
        }

        //add GOGGLEGOGGLE
        if (_goggleController == "goggle")
        {
            if (Input.GetKeyDown(interactKey))
            {
                //get the goggle or call goggle function here
            }
        }
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

    void ClearGlobe()
    {
        if(_globeController != null)
        {
            HeighlightCrosshair(false);
            _globeController = null;
        }
    }
    void ClearGoggle()
    {
        if (_goggleController != null)
        {
            HeighlightCrosshair(false);
            _goggleController = null;
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
