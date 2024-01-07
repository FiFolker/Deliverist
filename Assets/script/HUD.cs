using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


namespace FiFolker{

    public class HUD : MonoBehaviour {
        
        public UIDocument uiDocument;
        public CharacterBehavior player;
        private VisualElement root;
        private string moneyText = "Money : ";
        public Label interaction, money, info;
        private float timer = 0f;
        private int maxTime = 3;
        

        private void Start() {
            root = uiDocument.rootVisualElement;

            // Add your code here
            interaction = root.Q<Label>("Info");
            money = root.Q<Label>("Money");
            info = root.Q<Label>("Rewards");
            info.visible = false;
            interaction.visible = false;
            updateMoney();
        }

        

        public void DisplayInteraction(string text){
            timer = 0f;
            interaction.visible = true;
            interaction.text = text;
            TimerHide(interaction);
        }

        public void updateMoney(){
            money.text = moneyText + player.inventory.money + "€";
        }

        public void DisplayInfo(string text)
        {
            info.visible = true;
            info.text = text;
            TimerHide(info);

        }

        private void TimerHide(Label toHide){
            timer += Time.deltaTime;
            int seconds = (int)timer % 60;
            if(seconds >= maxTime){
                toHide.visible = false;
            }

        }
    }
}