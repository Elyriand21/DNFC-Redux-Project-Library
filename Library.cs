using MelonLoader;
using System.Collections.Generic;
using UnityEngine;


namespace DNFC_Redux_Library
{
    public class SharedData
    {
        public static bool IsInGame { get; set;}
        public static bool IsInLoading { get; set;}
        public static bool IsInMainMenu { get; set; }
        public static bool IsInitialized { get; set; }
        public static int WorkerCount { get; set; }
        public static Component SettingsManager { get; set; }
        public static GameObject CharactersInUse { get; set; }
        public static List<GameObject> Workers;
    }
    public class Library : MelonMod
    {
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
        // Check if the player is in the game
        public bool IsInGame()
        {
            return SharedData.IsInGame;
        }
        public bool SetIsInGame(bool inGame)
        {
            SharedData.IsInGame = inGame;
            return SharedData.IsInGame;
        }

        public bool IsInLoading()
        {
            return SharedData.IsInLoading;
        }
        public bool SetIsInLoading(bool inLoading)
        {
            SharedData.IsInLoading = inLoading;
            return SharedData.IsInLoading;
        }
        // Check if the player is in the main menu
        public bool IsInMainMenu()
        {
            return SharedData.IsInMainMenu;
        }
        public bool SetIsInMainMenu(bool inMainMenu)
        {
            SharedData.IsInMainMenu = inMainMenu;
            return SharedData.IsInMainMenu;
        }
        // Check if the mod has been initialized
        public bool IsInitialized()
        {
            return SharedData.IsInitialized; 
        }
        
        public void SetInitialized(bool initialized)
        {
               SharedData.IsInitialized = initialized;
        }

        public int GetWorkerListCount()
        {
            return SharedData.Workers.Count;
        }

        public int GetWorkerCount()
        {
            return SharedData.WorkerCount;
        }

        public void SetWorkerCount(int count)
        {
            SharedData.WorkerCount = count;
        }

        public void FindSettingsManagerComponent()
        {
            try
            {
                MelonLogger.Msg("Attempting to find SettingsManager GameObject...");
                Component settingsManager = GameObject.Find("SettingsManager")?.GetComponent("SettingsManager");
                MelonLogger.Msg("SettingsManager GameObject found: " + (settingsManager != null));
                SharedData.SettingsManager = settingsManager;
            }
            catch
            {
                MelonLogger.Msg("Error finding SettingsManager GameObject.");
            }
        }

        public Component GetSettingsManagerComponent()
        {
            if (SharedData.SettingsManager != null)
            {
                return SharedData.SettingsManager;
            }
            else
            {
                MelonLogger.Msg("GetSettingsManager: SettingsManager GameObject is not set.");
                return null;
            }

        }

        public void GetAllWorkers()
        {
            SharedData.Workers = new List<GameObject>();
            FindCharactersInUse();
            if (SharedData.CharactersInUse != null)
            {
                SetWorkerCount(SharedData.CharactersInUse.transform.childCount);
                MelonLogger.Msg("Total Workers found: " + SharedData.WorkerCount);
                for (int i = 0; i < SharedData.WorkerCount; i++)
                {
                    GameObject worker = SharedData.CharactersInUse.transform.GetChild(i).gameObject;
                    SharedData.Workers.Add(worker);
                }
            }
        }

        public void CheckWorkerCount()
        {
            if(SharedData.Workers.Count != SharedData.CharactersInUse.transform.childCount)
            {
                MelonLogger.Msg("Worker count has changed. Updating worker list...");
                GetAllWorkers();
            }
        }

        public void GetWorker()
        {
            if (SharedData.Workers != null)
            {
                for (int i = 0; i < SharedData.Workers.Count; i++)
                {
                    MelonLogger.Msg($"Worker {i}: {SharedData.Workers[i].name}");
                }
            }
        }

        public void FindCharactersInUse()
        {
            try
            {
                GameObject charactersInUse = GameObject.Find("CharactersInUse");
                SharedData.CharactersInUse = charactersInUse;

            }
            catch
            {
                MelonLogger.Msg("Error finding CharactersInUse GameObject.");
            }
        }

        public GameObject GetCharactersInUse()
        {
            if (SharedData.CharactersInUse != null)
            {
                return SharedData.CharactersInUse;
            }
            else
            {
                MelonLogger.Msg("GetCharactersInUse: CharactersInUse GameObject is not set.");
                return null;
            }
        }

        public bool GetActiveInHierarchy(GameObject obj)
        {
            if (obj != null)
            {
                return obj.activeInHierarchy;
            }
            else
            {
                MelonLogger.Msg("GetActive: Provided GameObject is null.");
                return false;
            }
        }
    }
}


