using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public int Coins = 50;
    public Text CoinsValueText;

    public Button BuyCreepButton;
    public Button SellCreepButton;
    public Button BuyTowerButton;
    public Button SellTowerButton;

    public Transform CreepZonePlayer1;

    private const int costCreep = 15;
    private const int costTower = 10;

    private List<Creep> listCreeps;
    private List<GameObject> listGameObjectsCreeps;
    private int countCreeps;

    void Start ()
	{
	    setTextCoins();

	    BuyCreepButton.onClick.AddListener(buyCreepButtonListener);
        SellCreepButton.onClick.AddListener(sellCreepButtonListener);
	    BuyTowerButton.onClick.AddListener(buyTowerButtonListener);

	    countCreeps = 0;
	    listCreeps = new List<Creep>();
        listCreeps.Add(new Creep(new Vector3(-3, 2), new Quaternion(0, 0, 0, 0), "Creep"));
	    listCreeps.Add(new Creep(new Vector3(-3, 1), new Quaternion(0, 0, 0, 0), "Creep"));
	    listCreeps.Add(new Creep(new Vector3(-3, 0), new Quaternion(0, 0, 0, 0), "Creep"));
	    listGameObjectsCreeps = new List<GameObject>();

	    checkActiveButton();
    }

    void setTextCoins()
    {
        CoinsValueText.text = Coins.ToString();
    }

    void buyCreepButtonListener()
    {
        Coins -= costCreep;
        setTextCoins();
        GameObject newCreep = Instantiate(
            (GameObject) Resources.Load(listCreeps[listGameObjectsCreeps.Count].Resourse), 
            listCreeps[listGameObjectsCreeps.Count].Position, 
            listCreeps[listGameObjectsCreeps.Count].Rotate
        );
        listGameObjectsCreeps.Add(newCreep);
        checkActiveButton();
    }

    void sellCreepButtonListener()
    {
        Coins += costCreep;
        setTextCoins();
        Destroy(listGameObjectsCreeps[listGameObjectsCreeps.Count - 1]);
        listGameObjectsCreeps.RemoveAt(listGameObjectsCreeps.Count - 1);
        checkActiveButton();
    }

    void buyTowerButtonListener()
    {
        Coins -= costTower;
        setTextCoins();
        checkActiveButton();
    }

    void checkActiveButton()
    {
        if (Coins < costCreep)
        {
            BuyCreepButton.interactable = false;
        }
        else
        {
            BuyCreepButton.interactable = true;
        }

        if (listGameObjectsCreeps.Count == 0)
        {
            SellCreepButton.interactable = false;
        }
        else
        {
            SellCreepButton.interactable = true;
        }

        if (Coins < costTower)
        {
            BuyTowerButton.interactable = false;
        }
        else
        {
            BuyTowerButton.interactable = true;
        }
    }

    private class Creep
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotate { get; set; }
        public String Resourse { get; set; }

        public Creep(Vector3 position, Quaternion rotate, String resourse)
        {
            Position = position;
            Rotate = rotate;
            Resourse = resourse;
        }
    }
}
