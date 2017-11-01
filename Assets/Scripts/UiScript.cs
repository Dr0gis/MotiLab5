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

    public Button StartButton;
    public GameObject FogWar;

    private const int CostCreep = 15;
    private const int CostTower = 10;

    private List<Creep> listCreeps;
    public List<GameObject> listGOCreepsPlayer1;
    public List<GameObject> listGOCreepsPlayer2;

    private List<Tower> listTowers;
    public List<GameObject> listGOTowersPlayer1;
    public List<GameObject> listGOTowersPlayer2;

    void Start ()
	{
	    setTextCoins();

	    BuyCreepButton.onClick.AddListener(buyCreepButtonListener);
        SellCreepButton.onClick.AddListener(sellCreepButtonListener);
	    BuyTowerButton.onClick.AddListener(buyTowerButtonListener);
        SellTowerButton.onClick.AddListener(sellTowersButtonListener);

        StartButton.onClick.AddListener(startButtonListener);

	    listCreeps = new List<Creep>
	    {
	        new Creep(new Vector3(-2.2f, 2), new Quaternion(0, 0, 0, 0), "Creep"),
	        new Creep(new Vector3(-2.1f, 1), new Quaternion(0, 0, 0, 0), "Creep"),
	        new Creep(new Vector3(-2, 0), new Quaternion(0, 0, 0, 0), "Creep")
	    };
	    listGOCreepsPlayer1 = new List<GameObject>();
	    listGOCreepsPlayer2 = new List<GameObject>();

        listTowers = new List<Tower>
	    {
	        new Tower(new Vector3(-3.9f, 2.5f), new Quaternion(0, 0, 0, 0), "Tower"),
	        new Tower(new Vector3(-3.8f, 1.5f), new Quaternion(0, 0, 0, 0), "Tower"),
	        new Tower(new Vector3(-3.7f, 0.5f), new Quaternion(0, 0, 0, 0), "Tower"),
	        new Tower(new Vector3(-3.6f, -0.5f), new Quaternion(0, 0, 0, 0), "Tower"),
	        new Tower(new Vector3(-3.5f, -1.5f), new Quaternion(0, 0, 0, 0), "Tower")
        };
	    listGOTowersPlayer1 = new List<GameObject>();
	    listGOTowersPlayer2 = new List<GameObject>();

        checkActiveButton();
    }

    void setTextCoins()
    {
        CoinsValueText.text = Coins.ToString();
    }

    void buyCreepButtonListener()
    {
        Coins -= CostCreep;
        setTextCoins();
        GameObject newCreep = Instantiate(
            (GameObject) Resources.Load(listCreeps[listGOCreepsPlayer1.Count].Resourse), 
            listCreeps[listGOCreepsPlayer1.Count].Position, 
            listCreeps[listGOCreepsPlayer1.Count].Rotate
        );
        listGOCreepsPlayer1.Add(newCreep);
        checkActiveButton();
    }
    void sellCreepButtonListener()
    {
        Coins += CostCreep;
        setTextCoins();
        Destroy(listGOCreepsPlayer1[listGOCreepsPlayer1.Count - 1]);
        listGOCreepsPlayer1.RemoveAt(listGOCreepsPlayer1.Count - 1);
        checkActiveButton();
    }

    void buyTowerButtonListener()
    {
        Coins -= CostTower;
        setTextCoins();
        GameObject newTower = Instantiate(
            (GameObject)Resources.Load(listTowers[listGOTowersPlayer1.Count].Resourse),
            listTowers[listGOTowersPlayer1.Count].Position,
            listTowers[listGOTowersPlayer1.Count].Rotate
        );
        listGOTowersPlayer1.Add(newTower);
        checkActiveButton();
    }
    void sellTowersButtonListener()
    {
        Coins += CostTower;
        setTextCoins();
        Destroy(listGOTowersPlayer1[listGOTowersPlayer1.Count - 1]);
        listGOTowersPlayer1.RemoveAt(listGOTowersPlayer1.Count - 1);
        checkActiveButton();
    }

    void checkActiveButton()
    {
        BuyCreepButton.interactable = !(Coins < CostCreep);

        SellCreepButton.interactable = listGOCreepsPlayer1.Count != 0;

        BuyTowerButton.interactable = !(Coins < CostTower);

        SellTowerButton.interactable = listGOTowersPlayer1.Count != 0;
    }

    void startButtonListener()
    {
        StartButton.interactable = false;

        System.Random random = new System.Random();
        int countCreep = random.Next(0, 4);
        int countTower = random.Next(0, (50 - countCreep * CostCreep) / CostTower + 1);

        // Clear lists
        foreach (var creep in listGOCreepsPlayer2)
        {
            Destroy(creep);
        }
        listGOCreepsPlayer2.Clear();
        foreach (var tower in listGOTowersPlayer2)
        {
            Destroy(tower);
        }
        listGOTowersPlayer2.Clear();
        
        // Fill lists
        for (int i = 0; i < countCreep; ++i)
        {
            GameObject newCreep = Instantiate(
                (GameObject)Resources.Load(listCreeps[listGOCreepsPlayer2.Count].Resourse),
                new Vector3(
                    Math.Abs(listCreeps[listGOCreepsPlayer2.Count].Position.x), 
                    listCreeps[listGOCreepsPlayer2.Count].Position.y
                ),
                new Quaternion(
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.x,
                    -180,
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.z,
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.w
                ) 
            );
            listGOCreepsPlayer2.Add(newCreep);
        }
        for (int i = 0; i < countTower; ++i)
        {
            GameObject newTower = Instantiate(
                (GameObject)Resources.Load(listTowers[listGOTowersPlayer2.Count].Resourse),
                new Vector3(
                    Math.Abs(listTowers[listGOTowersPlayer2.Count].Position.x), 
                    listTowers[listGOTowersPlayer2.Count].Position.y
                ),
                new Quaternion(
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.x,
                    -180,
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.z,
                    listCreeps[listGOCreepsPlayer2.Count].Rotate.w
                )
            );
            listGOTowersPlayer2.Add(newTower);
        }

        // Hide fog war
        FogWar.SetActive(false);


        foreach (var creep in listGOCreepsPlayer1)
        {
            creep.GetComponent<Rigidbody2D>().velocity = Vector2.right;
        }
        foreach (var creep in listGOCreepsPlayer2)
        {
            creep.GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }
    }

    public void result()
    {
        print("CreepPlayer1: " + listGOCreepsPlayer1.Count + " | TowerPlayer1: " + listGOTowersPlayer1.Count + " | CreepPlayer2: " + listGOCreepsPlayer2.Count + " | TowerPlayer2: " + listGOTowersPlayer2.Count);
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
    private class Tower
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotate { get; set; }
        public String Resourse { get; set; }

        public Tower(Vector3 position, Quaternion rotate, String resourse)
        {
            Position = position;
            Rotate = rotate;
            Resourse = resourse;
        }
    }
}
