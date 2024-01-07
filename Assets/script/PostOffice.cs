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
        public void draw()
        {
            Debug.Log("Press 'E' to interact with post office");
        }

        public void interact(CharacterBehavior player)
        {
            if(packageStorage.Count > 0){
                PackageData package = packageStorage[0];
                if(player.inventory.AddItem(package)) packageStorage.RemoveAt(0);
                else Debug.Log("Package not gived");
                
            }else{
                Debug.Log("Il n'y a plus de colis dans cette poste ...");
            }

        }

        void Start()
        {
            Debug.Log("Post office script loaded");
        }

        void Update()
        {
        
        }
    
    }
}
