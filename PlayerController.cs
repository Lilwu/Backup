using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float speed = 5.0f;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;

    public Inventory inventory;

    public HUD hud;

    public GameObject Hand;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        inventory.ItemUnUsed += Inventory_ItemUnUsed;
    }

    //使用武器
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        print("使用武器");
        IInventoryItem item = e.Item;

        //Do some with the object
        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = Hand.transform;
        goItem.transform.position = Hand.transform.position;
        goItem.transform.rotation = Hand.transform.rotation;
    }

    //卸除武器
    private void Inventory_ItemUnUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;
        GameObject UnUsedItem = (item as MonoBehaviour).gameObject;

        UnUsedItem.SetActive(false);
        UnUsedItem.transform.parent = inventory.transform; //卸除後移到inventory裡。
    }


    private IInventoryItem mItemToPickup = null;

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            hud.OpenMessagePanel();
            mItemToPickup = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            hud.CloseMessagePanel();
            mItemToPickup = null;
        }
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Limit to forward movement
        if (v < 0)
            v = 0;

        transform.Rotate(0, h * RotationSpeed * Time.deltaTime, 0);

        if (_characterController.isGrounded)
        {
            bool move = (v > 0 || h != 0);

            _animator.SetBool("IsWalk", move);

            _moveDir = Vector3.forward * v;

            _moveDir = transform.TransformDirection(_moveDir);

            _moveDir *= speed;
        }

        _moveDir.y -= Gravity * Time.deltaTime;

        _characterController.Move(_moveDir * Time.deltaTime);

        if (mItemToPickup != null && Input.GetKeyDown(KeyCode.V))
        {
            inventory.AddItem(mItemToPickup);
            mItemToPickup.OnPickup();
        }

    }

}
