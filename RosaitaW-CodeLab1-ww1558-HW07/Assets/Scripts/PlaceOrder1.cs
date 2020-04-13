using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceOrder1 : MonoBehaviour
{
    public GameObject OrderField;
    public Text OrderText;
    public InputField input;
    public TextAsset ListOfSandwiches;
    public Text display;
    public Text Description;
    public GameObject orderButton;
    public bool ChefIsDead = false;
    public List<string> sandwiches;
    public static PlaceOrder1 instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Instantiate the list
        sandwiches = new List<string>();

        // The below code reads the text file and splits it into lines.
        var sandwichFromFile = ListOfSandwiches.text.Split('\n');

        // This code loops though every single line in the text file
        for (var i = 0; i < sandwichFromFile.Length; i++)
        {
            // Add each line to the list of names.
            sandwiches.Add(sandwichFromFile[i].ToUpper());
        }
        Debug.Log("Count: " + sandwiches.Count);
    }

    public bool submit = false;
    public void Submit()
    {
        print("Name Submited: " + OrderText.text);
        //string[] names = OrderText.text.Split(' ');
        if (!submit)
        {
            submit = true;
        }
    }
    public void Typing()
    {
        if (submit)
        {
            submit = false;
        }
    }
    public void LeaveTheHouse()
    {
        SceneManager.LoadScene(0);
        sandwiches.Clear();

    }
    private void Update()
    {
        if (submit)
        {
            if (input.text == "")
            {
                display.text = "Enter the food's name";
            }
            // Otherwise, check to see if the name is in the list.
            else
            {
                // Start by setting the display to say "not in list".
                Description.text = "The chef wiped out her sweat and said: \n" + "Sorry, we don't have this. Is there any thing else I can do for you, sir? ";

                // Loop through the entire list
                for (int i = 0; i < sandwiches.Count; i++)
                {
                    // If any of the names in the list match what in the input field,
                    // say it's in the list.
                    if (input.text.ToUpper() == sandwiches[i])// && input.text.ToUpper() != "Chef")
                    {
                        Debug.Log("Matched!");
                        if (input.text != "Chef")
                        {
                            Debug.Log("Food!");
                            Description.text = "The chef offered you " + input.text.ToUpper() + " sandwiches. \n" + "You ate them. You're still hungry. ";
                        }
                        else if (input.text == "Chef")
                        {
                            Debug.Log("Chef!");
                            Description.text = "The chef tried to flee, but you were faster. You grabbed her and ate her. You're still hungry. ";
                            Destroy(OrderField);
                            Destroy(orderButton);
                            ChefIsDead = true;

                        }
                    }

                }

            }


        }
        // If there's nothing in the text box, show instructions.

    }
}
