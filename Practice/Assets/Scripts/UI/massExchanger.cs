using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class massExchanger : MonoBehaviour 
{
    private SaveManager sm;

	public int        toExchange;
	public float      coins;
	public GameObject massToExchangeObject;
	public GameObject coinsObject;
	public GameObject playerMassObject;

	float playerMass;
	Text  coinsInd;
	Text  massExchangeInd;
	Text  playerMassInd;

	void OnEnable()
	{

        sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();

		toExchange           = 100;
		massExchangeInd      = massToExchangeObject.GetComponent<Text> ();
		coinsInd             = coinsObject.GetComponent<Text> ();
		playerMassInd        = playerMassObject.GetComponent<Text> ();
        playerMass           = sm.playerMass;
        coins                = sm.coins;
		coinsInd.text        = ("Coins: " + coins);
		massExchangeInd.text = ("To exchange: " + toExchange);
		playerMassInd.text   = ("Mass: " + Mathf.RoundToInt(playerMass));
	}

	public void Exchange()
	{
		if (playerMass >= 100 && playerMass > toExchange && playerMass - toExchange >= 50) 
		{
			playerMass -= toExchange;
			// 1 coin - 100 mass
			coins               += (toExchange / 100);
			toExchange           = 100;
            sm.playerMass        = playerMass;
            sm.coins             = coins;
			coinsInd.text        = ("Coins: " + coins);
			playerMassInd.text   = ("Mass: " + Mathf.RoundToInt(playerMass));
			massExchangeInd.text = ("To exchange: " + toExchange);
		}
	}

	public void plusHundred()
	{
		toExchange          += 100;
		massExchangeInd.text = ("To exchange: " + toExchange);
	}

	public void plusThousand()
	{
		toExchange          += 1000;
		massExchangeInd.text = ("To exchange: " + toExchange);
	}

	public void minusHundred()
	{
		if (toExchange >= 200) 
		{
			toExchange          -= 100;
			massExchangeInd.text = ("To exchange: " + toExchange);
		}
	}

	public void minusThousand()
	{
		if (toExchange >= 2000) 
		{
			toExchange          -= 1000;
			massExchangeInd.text = ("To exchange: " + toExchange);
		}
	}

	public void reset()
	{
		toExchange           = 100;
		massExchangeInd.text = ("To exchange: " + toExchange);
	}
}
