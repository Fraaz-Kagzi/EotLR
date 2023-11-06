using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public static string[] purchasedItems;
    public static string equipedWeapon;
    public InventoryItem[] items;
    public Button[] equipButtons;

    // Start is called before the first frame update
    void Start(){

      if (purchasedItems != null) {
        for (int i = 0; i < purchasedItems.Length; i++) {
            items[i].gameObject.SetActive(true);
        }
        showItems();
      }
    }

    public void EquipButton(int btnNum){

      TMP_Text buttonText = equipButtons[btnNum].GetComponentInChildren<TMP_Text>();
      Debug.Log(buttonText.text);
      if (buttonText.text != "Equip"){
        buttonText.text = "Equip";
        equipedWeapon = null;
      }

      if (buttonText.text == "Unequip"){
        buttonText.text = "Unequip";
        equipedWeapon = purchasedItems[btnNum];
      }
    }


    public void ShopScene() {
      SceneManager.LoadScene("Shop");
    }

    public void showItems(){
      for (int i = 0; i < purchasedItems.Length; i++){
        items[i].name.text = purchasedItems[i];
      }
    }

    public static void addItems(string newItem){
      if (purchasedItems == null){

       purchasedItems = new string[] { newItem };

     } else{
       string[] newArray = new string[purchasedItems.Length + 1];

       for (int i = 0; i < purchasedItems.Length; i++){
           newArray[i] = purchasedItems[i];
       }

       newArray[purchasedItems.Length] = newItem;
       purchasedItems = newArray;
     }
   }
}
