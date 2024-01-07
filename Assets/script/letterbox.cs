using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiFolker
{
    public class letterbox : MonoBehaviour, Interaction
    {
        public void draw()
        {
            Debug.Log("Press 'E' to interact with letterbox");
        }

        public void interact(CharacterBehavior player)
        {
            foreach(PackageData package in player.inventory.content){
                if(package.type == PackageType.Small){
                    player.inventory.RemoveItem(package);
                    player.inventory.AddMoney(15);
                    break;
                }
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
