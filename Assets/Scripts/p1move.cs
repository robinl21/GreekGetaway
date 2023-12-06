using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class p1move : MonoBehaviour
{
    //MODIFYING: important stuff is all in OnMovementPerformed and FixedUpdate:
    public static p1move p1movement;
    private PlayerControls input = null; // set from PlayerControls.cs in scripts, generated from PlayerControls
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null; // attach velocity to move
    public float moveSpeed;

    public bool canMove = true; 

    public Inventory inventory; 

    // temporary inventory bools
    // #####################
    public bool hasPizza = false;

    public bool hasPhone = false;

    public bool hasDrink = false;

    public bool metJeff = false;
    // ###################

    public GameObject questLog;
    private void Awake()
    {
        p1movement = this;
        moveSpeed = 10f;
        input = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        // attaches these functions to callback when movement is performed/cancelled
        input.P1.Movement.performed += OnMovementPerformed;
        input.P1.Movement.canceled += OnMovementCancelled;

        input.P1.QuestLog.performed += OnQuestLogPerformed;

        input.P1.DropItem1.performed += OnDropItem1Performed;


    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("ISACTIVE");
    //     IInventoryItem item = other.GetComponent<IInventoryItem>();
    //     if (item != null) {
    //         inventory.AddItem(item);
    //     }
    // }
    

    private void OnDisable()
    {
        // just to make it clean so that when object is not loaded we don't accidentally trigger movement
        input.Disable();
        // p1's inputs are w,a,s,d as set in PlayerControls input map, so when w,a,s,d hit: we trigger these functions!
        input.P1.Movement.performed -= OnMovementPerformed;
        input.P1.Movement.canceled -= OnMovementPerformed;

        input.P1.QuestLog.performed -= OnQuestLogPerformed;
        input.P1.QuestLog.canceled -= OnQuestLogPerformed;


    }

    
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    //meat of the movement code: 
    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        // InputAction.CallbackContext value gives Vector2 based on direction, set by PlayerControls InputMap
        // left is [-1, 0] for ex
        if (canMove){
            moveVector = value.ReadValue<Vector2>();
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
        IInventoryItem toDrop = inventory.mItems[0];
        inventory.DropItem(toDrop, 0); //Inventory mList changed, #items changed, HUD also changed
    }
}
