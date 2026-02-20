using System;
using MelonLoader;
using System.Collections.Generic;
using UnityEngine;


namespace DNFC_Redux_Library
{
    public class CoreLib : MelonMod
    {
        // gonna redo this later, we need to create all the objects we need

        public static Util Utility;
        private SharedDataHandler _gameState;
        
        // Constructor, please init needed objects here
        public CoreLib()
        {
            Utility = new Util();
            _gameState = new SharedDataHandler();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case "MainMenu":
                    _gameState.Data.SceneState = SceneState.MainMenu;
                    break;
                case "Loading":
                    _gameState.Data.SceneState = SceneState.Loading;
                    break;
                case "CityGameplay":
                    _gameState.Data.IsInitialized = true;
                    _gameState.AttemptInit();
                    _gameState.Data.SceneState = SceneState.InGame;
                    break;
                default:
                    MelonLogger.Msg("Could not recognize scene: " + sceneName);
                    break;
            }
            MelonLogger.Msg($"Scene loaded: {sceneName}, ");
        }

        public override void OnEarlyInitializeMelon()
        {
            MelonLogger.Msg(@"

         ___  _  _ ___ ___   ___        _            _    _ _                      
        |   \| \| | __/ __| | _ \___ __| |_  ___ __ | |  (_) |__ _ _ __ _ _ _ _  _ 
        | |) | .` | _| (__  |   / -_) _` | || \ \ / | |__| | '_ \ '_/ _` | '_| || |
        |___/|_|\_|_| \___| |_|_\___\__,_|\_,_/_\_\ |____|_|_.__/_| \__,_|_|  \_, |
                                                                              |__/ 
    From everyone at the DNFC Redux Project, we hope you enjoy 
    this mod and the work we've put into it. If you have any questions, 
    suggestions, or want to contribute, feel free to join our Discord server!

");
        }
    }
}


