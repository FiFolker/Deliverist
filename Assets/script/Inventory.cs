using System.Collections.Generic;
using UnityEngine;


namespace FiFolker{
    public class Inventory : MonoBehaviour {
        public List<PackageData> content = new List<PackageData>();
        
        public int money = 0;
        public float maxWeight;
        private float currentWeight = 0f;
        public CharacterBehavior player;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.I)){
                player.hud.DisplayInfo("You have " + content.Count + " items for a total of " + currentWeight + "/"+maxWeight+"kg");
            }
        }

        public bool AddItem(PackageData package){
            if(currentWeight+package.weight <= maxWeight){
                content.Add(package);
                currentWeight += package.weight;
                player.hud.DisplayInfo("+ " +package.name + " | weight : " + currentWeight + "kg");
                return true;
            }else{
                player.hud.DisplayInfo("Out of Weight ...");
                return false;
            }
        }

        public void RemoveItem(PackageData package){
            content.Remove(package);
            currentWeight -= package.weight;
            player.hud.DisplayInfo("- " + package.name + " | - "+package.weight+"kg");
        }

        public void AddMoney(int amount){
            player.hud.DisplayInfo("+ "+amount+"€");
            money += amount;
            player.hud.updateMoney();
        }

    }
}
    