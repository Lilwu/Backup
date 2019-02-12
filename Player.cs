using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //角色屬性
    static int _maxHp;
    static int _hp;
    static int _maxMp;
    static int _mp;

    public Inventory inventory;
    static Player instance;

    //使用武器測試
    public GameObject Hand;
    //使用武器測試


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

            _maxHp = 999;
            _hp = _maxHp;

            _maxMp = 499;
            _mp = _maxMp;
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            print("刪除" + sceneName + "的" + name);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //使用武器測試
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        //Do some with the object
        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = Hand.transform;
        goItem.transform.position = Hand.transform.position;
    }

    //使用武器測試

    /*
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {   
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }
    */

    private void OnCollisionEnter(Collision other)
    {
        IInventoryItem item = other.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }



    //讀取HP及MP
    public int HP
    {
        get { return _hp; }
    }
    public int MaxHP
    {
        get { return _maxHp; }
    }
    public int MP
    {
        get { return _mp; }
    }
    public int MaxMP
    {
        get { return _maxMp; }
    }


    private void FixedUpdate()
    {
        
    }
}