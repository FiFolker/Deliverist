using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiFolker
{
    public class letterbox : MonoBehaviour, Interaction
    {

        public void draw(CharacterBehavior player)
        {
            player.hud.DisplayInteraction("Press '"+player.interactionInput.ToString()+"' to interact with letterbox");
            
        }

        public void interact(CharacterBehavior player)
        {
            foreach(PackageData package in player.inventory.content){
                if(package.type == PackageType.Small){
                    player.inventory.RemoveItem(package);
                    player.inventory.AddMoney(15);
                    player.hud.DisplayInteraction("+ 15€");
                    break;
                }
            }
            
        }

    }
}
