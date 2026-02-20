using System.Collections.Generic;
using UnityEngine;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// This class is intended for internal use by the REDUX project team, it contains references to all important Game objects and components in the game, as well as important game state information.
    /// </summary>
    public class SharedData
    {
        public SceneState SceneState {get; set;}
        public bool IsInitialized { get; set; }
        public Component SettingsManager { get; set; }
        public GameObject CharactersInUse { get; set; }
        public Component ProgressionCoordinator { get; set; }
    }

    public enum SceneState
    {
        MainMenu,
        Loading,
        InGame,
    }
    
}