using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject BurgerButton;
    public GameObject SandwichButton;
    public Text Title;
    // Start is called before the first frame update
    void Start()
    {
        BurgerButton.SetActive(false);
        SandwichButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Title.text == "The Burger House")
        {
            BurgerButton.SetActive(true);
            SandwichButton.SetActive(false);
        }
        else if (Title.text == "The Sandwich House")
        {
            SandwichButton.SetActive(true);
            BurgerButton.SetActive(false);
        }
        else
        {
            BurgerButton.SetActive(false);
            SandwichButton.SetActive(false);
        }
    }
}
