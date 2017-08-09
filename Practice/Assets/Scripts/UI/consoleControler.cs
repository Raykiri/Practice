using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class consoleControler : MonoBehaviour 
{
    public  GameObject  scrollView;
    private InputField  inputField;
    private Text        scrollViewContent;
    private SaveManager saveManager;

    void Start() 
    {
        saveManager            = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        scrollView             = GameObject.Find("Scroll View");
        inputField             = gameObject.GetComponent<InputField>();
        scrollViewContent      = scrollView.GetComponentInChildren<Text>();
        scrollViewContent.text = "";
    }

    public void checkCommand() 
    {
        int    value;
        string command     = inputField.text;
        string stringToInt = "";
        float  playerMass  = saveManager.playerMass;
        float  coins       = saveManager.coins;

        if (command.Contains("/add " + "coins"))
        {
            value                   = convertStringToInt(command, stringToInt);
            coins                  += value;
            saveManager.coins       = coins;
            scrollViewContent.text += ("Coins added: " + value + "\n");
        }
        else if (command.Contains("/set " + "coins"))
        {
            value                   = convertStringToInt(command, stringToInt);
            saveManager.coins       = value;
            scrollViewContent.text += ("Coins setted to: " + value + "\n");
        }
        else if (command.Contains("/add " + "mass"))
        {
            value                   = convertStringToInt(command, stringToInt);
            playerMass             += value;
            saveManager.playerMass  = playerMass;
            scrollViewContent.text += ("Mass added: " + value + " Now Player mass is: " + saveManager.playerMass + "\n");
        }
        else if (command.Contains("/set " + "mass"))
        {
            value                   = convertStringToInt(command, stringToInt);
            playerMass              = value;
            saveManager.playerMass  = playerMass;
            scrollViewContent.text += ("Player mass setted to: " + value + "\n");
        }
        else if (command.Contains("/set enemies on"))
        {
            PlayerPrefs.SetInt("ESpawn", 1);
            scrollViewContent.text += ("Enemies Spawn turned on \n");
        }
        else if (command.Contains("/set enemies off"))
        {
            PlayerPrefs.SetInt("ESpawn", 0);
            scrollViewContent.text += ("Enemies Spawn turned off\n");
        }
        else if (command.Contains("/set " + "exp"))
        {
            value                         = convertStringToInt(command, stringToInt);
            saveManager.playerExperience  = value;
            scrollViewContent.text       += ("Experience setted to " + value + "\n");
        }
        else if (command.Contains("/add " + "exp"))
        {
            value                         = convertStringToInt(command, stringToInt);
            saveManager.playerExperience += value;
            scrollViewContent.text       += ("Experience added " + value + "\n");
        }
        else if(command.Contains("/set level"))
        {
            value                   = convertStringToInt(command, stringToInt);
            saveManager.playerLevel = value;
            scrollViewContent.text += ("Player level setted to " + value + "\n");
        }
        else if (command.Contains("/add level"))
        {
            value                    = convertStringToInt(command, stringToInt);
            saveManager.playerLevel += value;
            scrollViewContent.text  += ("Player level increased by " + value + "\n");
        }
        else if(command == "/help")
        {
            scrollViewContent.text += ("/add coins 'value' - adds 'value' coins\n ");
            scrollViewContent.text += ("/set coins 'value' - sets coins equal to 'value'\n ");
            scrollViewContent.text += ("/add mass 'value' - adds 'value' to player mass\n ");
            scrollViewContent.text += ("/set mass 'value' - sets player mass equal to 'value'\n ");
            scrollViewContent.text += ("/set enemies on/off - turns enemies spawn on/off\n ");
            scrollViewContent.text += ("/set exp 'value' - set experience equal to 'value'\n ");
            scrollViewContent.text += ("/add exp 'value' - adds 'value' to experience\n ");
            scrollViewContent.text += ("/set level 'value' - sets player level to 'value'\n ");
            scrollViewContent.text += ("/add level 'value' - adds 'value' to player level\n ");
        }
        else
        {
            scrollViewContent.text += "Invalid command please try aggain.\n";
        }        
    }
    
    int convertStringToInt(string command, string stringToInt)
    {
        char[] a = command.ToCharArray();
        foreach (char b in a)
        {
            if (char.IsDigit(b))
            {
                // stringValue is value in string type 
                stringToInt = (stringToInt + b);
                /* 
                 * Adds to that string value.
                 * For example, 
                 * stringValue = ""
                 * b = "1"  ('b' is char type variable)
                 * stringValue = ("" + '1'.ToString())
                 * stringValue == "1"
                 * Again foreach loop
                 * b = "2"
                 * stringValue = ("1" + '2'.ToString())
                 * stringValue == "12"
                 * Again foreach loop
                 * b = "5"
                 * stringValue = ("12" + '5'.ToString())
                 * stringValue == "125"
                */
            }
        }
        int value;
        int.TryParse(stringToInt, out value);
        return value;
    }

}
