using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FiFolker
{
    public class PostOffice : MonoBehaviour, Interaction
    {

        [Header("Items")]
        public List<PackageData> packageStorage;
        public void draw(CharacterBehavior player)
        {
            player.hud.DisplayInteraction("Press '"+player.interactionInput.ToString()+"' to interact with the post office");
        }

        public void interact(CharacterBehavior player)
        {
            if(packageStorage.Count > 0){
                PackageData package = packageStorage[0];
                if(player.inventory.AddItem(package)) packageStorage.RemoveAt(0);
                else player.hud.DisplayInfo("Package not gived ...");
                
            }else{
                player.hud.DisplayInfo("Post office out of stock");
            }

        }
    
    }
}
