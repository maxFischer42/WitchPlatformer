using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brewing : MonoBehaviour {

    public Inventory m_inventory;
    private bool isOpen = false;
    private Canvas brewCanvas;

    private WandHealth m_wandHealth;
    private Attack m_attack;

    public Recipe GreenRecipe;
    public Recipe RedRecipe;
    public Recipe PurpleRecipe;

    public Items[] ingredients;

    // Use this for initialization
    void Start() {
        m_wandHealth = GameObject.Find("Player").GetComponentInChildren<WandHealth>();
        m_attack = m_wandHealth.GetComponentInParent<Attack>();
        brewCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Brewing"))
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
        checkGreen(currentInventory, recipe);
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

    bool CheckIfOwned(Items require)
    {
        for(int i = 0; i < m_inventory.items.Length; i++)
        {
            if (m_inventory.items[i] == require)
                return true;
        }
        return false;
    }



    public void DelItemsSlime()
    {
        if (CheckIfOwned(ingredients[0]))
            m_wandHealth.health++;
        Debug.Log("Clear Inventory");
        m_inventory.RemoveItem(ingredients[0]);
        
    }

    public void DelItemsBone()
    {
        if (CheckIfOwned(ingredients[1]))
            m_attack.wand.attackRate -= 0.05f;
        Debug.Log("Clear Inventory");
        m_inventory.RemoveItem(ingredients[1]);
    }

    public void DelItemsFlesh()
    {
        if (CheckIfOwned(ingredients[2]))
            m_attack.wand.Speed += 0.1f;
        Debug.Log("Clear Inventory");
        m_inventory.RemoveItem(ingredients[2]);
    }

    public void DelItemsFlower()
    {
        if (CheckIfOwned(ingredients[3]))
            m_wandHealth.health+= 5;
        Debug.Log("Clear Inventory");
        m_inventory.RemoveItem(ingredients[3]);
    }

    public void DelItemsScale()
    {
        if (CheckIfOwned(ingredients[4]))
            m_wandHealth.health += 10;
        Debug.Log("Clear Inventory");
        m_inventory.RemoveItem(ingredients[4]);
    }

}
