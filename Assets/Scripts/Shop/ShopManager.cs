using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ShopManager : MonoBehaviour
{

    public TMP_Text coinsText;
    public ShopItemSO[] shopItemSO;
    public ShopTemplate[] shopPanels;
    public Button[] purchaseButtons;


    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i < shopItemSO.Length; i++) {
          shopPanels[i].gameObject.SetActive(true);
      }
      coinsText.text = "Coins: " + CoinManager.playerCoins.ToString();
      loadPanels();
      checkPurchasable();
    }

    public void ChangeScene() {
      SceneManager.LoadScene(1);
    }

    public void loadPanels(){
      for (int i = 0; i < shopItemSO.Length; i++){
        shopPanels[i].title.text = shopItemSO[i].title;
        shopPanels[i].priceTxt.text = "Coins: " + shopItemSO[i].price.ToString();
      }
    }

    public void checkPurchasable(){
      for (int i =0; i < shopItemSO.Length; i++){
        if (CoinManager.playerCoins > shopItemSO[i].price){
          // Buy
          purchaseButtons[i].interactable = true;
        }else{
          purchaseButtons[i].interactable = false;
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
