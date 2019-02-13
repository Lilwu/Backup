using System;
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
    static int _lv;

    static Player instance;



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

            _lv = 1;
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            print("刪除" + sceneName + "的" + name);
            Destroy(gameObject);
        }
    }
    //角色觸及物品自動撿起物品

    /*
private void OnCollisionEnter(Collision other)
{
    IInventoryItem item = other.collider.GetComponent<IInventoryItem>();
    if (item != null)
    {
        //inventory.AddItem(item);

    }
}    */



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
    public int LV
    {
        get { return _lv; }
    }

}