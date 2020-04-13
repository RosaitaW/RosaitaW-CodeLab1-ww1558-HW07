using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerList : MonoBehaviour
{
    public InputField input;
    public TextAsset ListOfBurgers;
    public Text display;
    public Text Description;

    private List<string> burgers;

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
    }

    private void Update()
    {
        // If there's nothing in the text box, show instructions.
        
        if (input.text == "")
        {
            display.text = "Enter the food's name";
        }
        // Otherwise, check to see if the name is in the list.
        else
        {
            // Start by setting the display to say "not in list".
            Description.text = "The chef wiped out his sweat again and said: \n"+"Sorry, we don't have this. Is there any thing else I can do for you, sir? ";

            // Loop through the entire list
            for (int i = 0; i < burgers.Count; i++)
            {
                // If any of the names in the list match what in the input field,
                // say it's in the list.
                if (input.text.ToUpper() == burgers[i] && input.text.ToUpper() !="Chef")
                {
                    Description.text = "The chef offered you "+input.text.ToUpper()+". \n"+"You ate them. You're still hungry. ";
                }
                if(input.text.ToUpper() == "Chef")
                {
                    Description.text = "The chef tried to flee, but you were faster. You grabed him and ate him. You're still hungry. ";
                    burgers.Clear();
                }
            }

        }
    }
}
