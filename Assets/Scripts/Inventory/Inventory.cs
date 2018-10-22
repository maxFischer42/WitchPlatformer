using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Items[] items = new Items[numItemSlots];
    public const int numItemSlots = 4;
    public int GreenPotions = 0;
    public int RedPotions = 0;
    public int PurplePotions = 0;
    public int currentPotion = 0;

    public void AddItem(Items itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(Items itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
}