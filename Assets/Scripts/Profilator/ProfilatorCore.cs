using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

namespace Profilator
{
    public class ProfilatorCore : MonoBehaviour
    {
        public ProfilatorModule[] _modules;
        public ProfilatorConfig _config;
        public IModuleBaseProvider _baseProvider;

        private void Start()
        {
            FindModules();           
        }

        private void FindModules()
        {
            _modules = GetComponentsInChildren<ProfilatorModule>();
        }

        void Update()
        {
            foreach (var module in _modules)
            {
                
            }            
        }
    }
}

