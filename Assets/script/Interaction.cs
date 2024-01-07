using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiFolker{

    public interface Interaction
    {
        public void draw(CharacterBehavior player);
        public void interact(CharacterBehavior player);
        
    }

}

