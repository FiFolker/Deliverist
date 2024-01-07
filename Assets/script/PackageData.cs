using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiFolker
{
    [CreateAssetMenu(fileName = "PackageData", menuName = "Scriptable Objects/Package Data")]
    public class PackageData : ScriptableObject
    {
        public PackageType type;
        public float weight;
        public GameObject packageModel;
        
    }
    public enum PackageType
    {
        Small,
        Medium,
        Large
    }
}
