using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brewing : MonoBehaviour {

    public Inventory m_inventory;
    private bool isOpen = false;
    private Canvas brewCanvas;

    public Recipe GreenRecipe;
    public Recipe RedRecipe;
    public Recipe PurpleRecipe;

	// Use this for initialization
	void Start () {
        brewCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Brewing"))
        {
            brewCanvas.enabled = true;
        }
        else if (Input.GetButtonUp("Brewing"))
        {
            brewCanvas.enabled = false;
        }
    }

    public void clickGreen()
    {
        Items[] currentInventory = m_inventory.items;
        Items[] recipe = GreenRecipe.ingredients;
        checkGreen(currentInventory,recipe);
    }



    void checkGreen(Items[] currentInventory, Items[] recipeRequirements)
    {
        int counter = 0;
        for (int i = 0; i < recipeRequirements.Length; i++)
        {
            if (currentInventory[i] == recipeRequirements[0])
            {
                counter++;
            }
        }
        if (counter == 4)
        {
            m_inventory.RemoveItem(GreenRecipe.ingredients[0]);
            m_inventory.RemoveItem(GreenRecipe.ingredients[1]);
            m_inventory.RemoveItem(GreenRecipe.ingredients[2]);
            m_inventory.RemoveItem(GreenRecipe.ingredients[3]);
            m_inventory.GreenPotions++;
        }
    }




}
