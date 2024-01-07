using System.Collections.Generic;
using UnityEngine;


namespace FiFolker{
    public class Inventory : MonoBehaviour {
        public List<PackageData> content = new List<PackageData>();
        
        public int money = 0;
        public float maxWeight;
        private float currentWeight = 0f;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.I)){
                Debug.Log("You have " + content.Count + " items for a total of " + currentWeight + "/"+maxWeight+"kg");
            }
        }

        public bool AddItem(PackageData package){
            if(currentWeight+package.weight <= maxWeight){
                content.Add(package);
                currentWeight += package.weight;
                Debug.Log(package.name + " was added to your inventory. Current weight : " + currentWeight);
                return true;
            }else{
                Debug.Log("Out of weight ...");
                return false;
            }
        }

        public void RemoveItem(PackageData package){
            content.Remove(package);
            currentWeight -= package.weight;
            Debug.Log(package.name + " was removed of the inventory. - "+package.weight+"kg");
        }

        public void AddMoney(int amount){
            money += amount;
            Debug.Log("+ "+amount+"€");
            Debug.Log("You have " + money + "€");
        }

    }
}
    