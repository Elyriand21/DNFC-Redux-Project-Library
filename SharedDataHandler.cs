using System;
using MelonLoader;
using System.Collections.Generic;
using UnityEngine;


namespace DNFC_Redux_Library
{
    public class SharedDataHandler
    {
        private Util _utility = CoreLib.Utility;
        public SharedData Data { get; private set; }

        public SharedDataHandler()
        {
         // empty for now   
        }
        
        internal void AttemptInit()
        {
            InitFetchComponents();
            InitFetchGameObjects();
        }

        private void InitFetchComponents()
        {
            FindSettingsManagerComponent();
            FindProgressionCoordinatorComponent();
        }

        private void InitFetchGameObjects()
        {
            FindCharactersInUse();
        }
        
        private void FindSettingsManagerComponent()
        {
            if (_utility.TryFetchComponentFromGameObj("SettingsManager", "SettingsManager",  out Component component))
            {
                Data.SettingsManager = component;
            }
        }

        private void FindProgressionCoordinatorComponent()
        {
            if (_utility.TryFetchComponentFromGameObj("Managers", "ProgressionClientsCoordinator", out Component component))
            {
                Data.ProgressionCoordinator = component;
            }
        }
        
        private void FindCharactersInUse()
        {
            if (_utility.TryFetchGameObjectFromHierarchy("CharactersInUse", out GameObject gameObject))
                Data.CharactersInUse = gameObject;
        }
        
    }
}