using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsListEmpty : MonoBehaviour
{
    public TextAsset burgersList;
    public TextAsset sandwichesList;
    public Text Title;
    public Text Description;
    public PlaceOrder PlaceOrder;
    public PlaceOrder1 PlaceOrder1;
    public GameObject EnterBurgerHouse;
    public GameObject EnterSandwichHouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Title.text == "The Burger House" && PlaceOrder.ChefIsDead==true) {
            Description.text = "Nothing to eat here, better look for somewhere else. ";
            Destroy(EnterBurgerHouse);
        }else if(Title.text=="The Sandwich House" && PlaceOrder1.ChefIsDead==true){
            Description.text = "Nothing to eat here, better look for somewhere else. ";
            Destroy(EnterSandwichHouse);

        }
    }
}
