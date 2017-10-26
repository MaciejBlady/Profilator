using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModuleBaseProvider
{
}


[CreateAssetMenu(menuName = "Profilator/Config")]
public class ProfilatorConfig : ScriptableObject, IModuleBaseProvider
{
    public System.Type[] _types;
    public string asdasd;
    public GameObject _obj;
    private void OnEnable()
    {
        
    }
}
