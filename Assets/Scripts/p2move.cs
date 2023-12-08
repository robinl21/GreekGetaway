using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class p2move : MonoBehaviour
{
    //MODIFYING: important stuff is all in OnMovementPerformed and FixedUpdate:
    public static p2move p2movement;
    private PlayerControls input = null; // set from PlayerControls InputMap in scripts
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null; // attach velocity to move

    private float drunkCountdownTimer = 30.0f;
    public float moveSpeed;
    public bool canMove = true; 

    public bool isDrunk = false;

    public Inventory2 inventory; 

    public GameObject questLog;

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;


    // temporary inventory bools
    // #####################

    public bool metJeff = false;
    // ###################
    private void Awake()
    {
        p2movement = this;
        moveSpeed = 10f;
        input = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("ISACTIVE");
    //     IInventoryItem item = other.GetComponent<IInventoryItem>();
    //     if (item != null) {
    //         inventory.AddItem2(item);
    //     }
    // }

    private void OnEnable()
    {
        input.Enable();
        // attaches these functions to callback when movement is performed/cancelled
        input.P2.Movement.performed += OnMovementPerformed;
        input.P2.Movement.canceled += OnMovementCancelled;

        input.P2.QuestLog.performed += OnQuestLogPerformed;

        input.P2.DropItem1.performed += OnDropItem1Performed;
    }

    private void OnDisable()
    {
        // just to make it clean so that when object is not loaded we don't accidentally trigger movement
        input.Disable();
        // p1's inputs are w,a,s,d as set in PlayerControls input map, so when w,a,s,d hit: we trigger these functions!
        input.P2.Movement.performed -= OnMovementPerformed;
        input.P2.Movement.canceled -= OnMovementPerformed;
    }
    
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;

        // Make the player drunk when a certain time has passed.
        drunkCountdownTimer -= Time.deltaTime;
        if (drunkCountdownTimer <= 0) 
        {
            isDrunk = true;
            Debug.Log("Is now Drunk");
        }
    }

    //meat of the movement code: 
    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        // InputAction.CallbackContext value gives Vector2 based on direction, set by PlayerControls InputMap
        // left is [-1, 0] for ex
        if (canMove) {
            Vector2 inputVector = value.ReadValue<Vector2>();
            float x = inputVector.x;
            float y = inputVector.y;
            if (isDrunk)
            {
                x = x * -1;
                y = y * -1;
            }

            //Alter sprite
            if (y == -1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
            }
            else if (y == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
            }
            else if (x == -1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            }
            else if (x == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            }

            moveVector = new Vector2(x, y);
        }

    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {   // stops player
        moveVector = Vector2.zero;

    }

    private void OnQuestLogPerformed(InputAction.CallbackContext value) {
        bool isActive = this.questLog.activeSelf;
        this.questLog.SetActive(!isActive);
    }

    private void OnDropItem1Performed(InputAction.CallbackContext value) {
        // modify inventory: call dropItem
        IInventoryItem toDrop = inventory.mItems2[0];
        inventory.DropItem2(toDrop, 0); //Inventory mList changed, #items changed, HUD also changed
    }
}
