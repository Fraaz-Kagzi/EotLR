using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public static string[] purchasedItems;
    public static string[] equipedWeapons = new string[] { null, null };
    public InventoryItem[] items;
    public Button[] equipButtons;
    public bool[] isEquipped;
    public GameObject alertMessage;

    // Start is called before the first frame update
    void Start(){
      isEquipped = new bool[equipButtons.Length];
      if (purchasedItems != null) {
        for (int i = 0; i < purchasedItems.Length; i++) {
            items[i].gameObject.SetActive(true);
        }
        showItems();
        displayEquipState();
      }
    }

    public void EquipButton(int btnNum){

      TMP_Text buttonText = equipButtons[btnNum].GetComponentInChildren<TMP_Text>();


      if (isEquipped[btnNum] == false){
        buttonText.text = "Unequip";
        addEquipedWeapon(purchasedItems[btnNum]);
        isEquipped[btnNum] = true;
      }else{
        buttonText.text = "Equip";
        removeEquipedWeapon(purchasedItems[btnNum]);
        isEquipped[btnNum] = false;
      }
    }

    public void displayEquipState(){
      for (int i =0; i < items.Length; i++){
        for(int j=0; j < equipedWeapons.Length; j++){
          if (equipedWeapons[j] == items[i].name.text){
            TMP_Text buttonText = equipButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = "Unequip";
            isEquipped[i] = true;
          }
        }
      }
    }

    public void addEquipedWeapon(string itemName){
      for (int i = 0; i < equipedWeapons.Length; i++){
        if(equipedWeapons[i] == null){
          equipedWeapons[i] = itemName;
          break;
        }
      }
    }


    public void removeEquipedWeapon(string itemName){
      for (int i = 0; i < equipedWeapons.Length; i++){
        if(equipedWeapons[i] == itemName){
          equipedWeapons[i] = null;
          break;
        }
      }
    }


    public void ShopScene() {
      SceneManager.LoadScene("Shop");
    }

    public void GameScene() {
      bool found = false;
      for (int i = 0; i < equipedWeapons.Length; i++){
        if(equipedWeapons[i] != null){
          SceneManager.LoadScene("SampleScene");
          found =  true;
        }
      }

      if (found == false){
        alertMessage.SetActive(true);
      }
      
    }

    public void showItems(){
      for (int i = 0; i < purchasedItems.Length; i++){

        items[i].name.text = purchasedItems[i];
      }
    }

    public static void addItems(string newItem)
  {
    if (purchasedItems == null)
    {
        purchasedItems = new string[] { newItem };
    }
    else
    {
        string[] newArray = new string[purchasedItems.Length + 1];

        for (int i = 0; i < purchasedItems.Length; i++)
        {
            newArray[i] = purchasedItems[i];
        }

        newArray[newArray.Length - 1] = newItem;
        purchasedItems = newArray;
    }
}
}
