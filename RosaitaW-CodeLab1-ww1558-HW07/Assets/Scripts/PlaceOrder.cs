using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceOrder : MonoBehaviour
{
    public GameObject OrderField;
    public Text OrderText;
    public InputField input;
    public TextAsset ListOfBurgers;
    public Text display;
    public Text Description;
    public GameObject orderButton;
    public bool ChefIsDead=false;
    public List<string> burgers;
    public static PlaceOrder instance;
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
        burgers = new List<string>();

        // The below code reads the text file and splits it into lines.
        var burgersFromFile = ListOfBurgers.text.Split('\n');

        // This code loops though every single line in the text file
        for (var i = 0; i < burgersFromFile.Length; i++)
        {
            // Add each line to the list of names.
            burgers.Add(burgersFromFile[i].ToUpper());
        }
        Debug.Log("Count: " + burgers.Count);
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
    public void Typing() {
        if (submit) {
            submit = false;
            Debug.Log("false");
        }
    }
    public void LeaveTheHouse()
    {
        SceneManager.LoadScene(0);
        burgers.Clear();
        
    }
    private void Update()
    {
        if (submit) {
            if (input.text == "")
            {
                display.text = "Enter the food's name";
            }
            // Otherwise, check to see if the name is in the list.
            else
            {
                // Start by setting the display to say "not in list".
                Description.text = "The chef wiped out his sweat again and said: \n" + "Sorry, we don't have this. Is there any thing else I can do for you, sir? ";

                // Loop through the entire list
                for (int i = 0; i < burgers.Count; i++)
                {
                    // If any of the names in the list match what in the input field,
                    // say it's in the list.
                    if (input.text.ToUpper() == burgers[i])// && input.text.ToUpper() != "Chef")
                    {
                        Debug.Log("Matched!");
                        if (input.text != "Chef")
                        {
                            Debug.Log("Food!");
                            Description.text = "The chef offered you " + input.text.ToUpper() + " burgers. \n" + "You ate them. You're still hungry. ";
                        } else if(input.text == "Chef")
                        {
                            Debug.Log("Chef!");
                            Description.text = "The chef tried to flee, but you were faster. You grabbed him and ate him. You're still hungry. ";
                            Destroy(OrderField);
                            Destroy(orderButton);
                            submit = true;
                            ChefIsDead = true;
                            //burgers.RemoveAt(i);
                        }
                    }
                    
                }

            }
           

        }
        // If there's nothing in the text box, show instructions.
        
    }
}
