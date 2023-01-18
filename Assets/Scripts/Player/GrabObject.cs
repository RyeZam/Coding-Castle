using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private Transform dropPoint;

    private GameObject grabbedObject;
    private int layerIndex;
    SpriteRenderer sprite;
    public Vector2 lookdir;
    private bool canHold;

    public bool isHolding;

   /* public Playerinputactions playerControls;
    private InputAction interact;

    private void Awake()
    {
        playerControls = new Playerinputactions();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        sprite = GetComponent<SpriteRenderer>();
        canHold = true;
    }

    // Update is called once per frame
    void Update()
    {
        lookdir = GetComponent<PlayerMove>().export;

        Physics2D.queriesStartInColliders = false;
  
     RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, lookdir, rayDistance);


         if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex && Keyboard.current.eKey.wasPressedThisFrame)
         {
            //canHold = true;
                if (canHold)
                {
                    isHolding = true;
                    grabbedObject = hitInfo.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabbedObject.transform.SetParent(transform);
                    grabbedObject.transform.position = grabPoint.transform.position;
                    canHold = false;
                }
        }
        else if (isHolding && Keyboard.current.eKey.wasPressedThisFrame)
        {
            canHold = true;
            isHolding = false;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.position = dropPoint.transform.position;
            grabbedObject.transform.SetParent(null, true);
        }
    }
}
