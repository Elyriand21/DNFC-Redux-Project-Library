using System;
using MelonLoader;
using System.Collections.Generic;
using UnityEngine;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// Utility class for basic utilities like fetching components and objects
    /// </summary>
    public class Util: MelonMod
    {
        /// <summary>
        /// Attemtps to fetch component from a gameObject from the hierarchy.
        /// </summary>
        /// <param name="gameObjectName"> Name of Object to search for</param>
        /// <param name="componentName"> Name of component to get</param>
        /// <param name="component"> When this method returns, contains the component or <c>null</c> if not found</param>
        /// <returns><c>true</c> if component was found, otherwise returns <c>false</c></returns>
        internal bool TryFetchComponentFromGameObj(string gameObjectName, string componentName, out Component component)
        {
            component = null;
            try
            {
                MelonLogger.Msg($"Attempting to find {gameObjectName} GameObject...");
                GameObject gameObject = GameObject.Find(gameObjectName);

                if (gameObject == null)
                {
                    MelonLogger.Msg($"No game object with name {gameObjectName} was found.");
                    return false;
                }

                MelonLogger.Msg($"Found game object with name: {gameObjectName}.");
                MelonLogger.Msg($"Attempting to find {componentName} component on {gameObjectName}...");

                component = gameObject.GetComponent(componentName);
                if (component == null)
                {
                    MelonLogger.Msg($"No component with name {componentName} found on {gameObjectName}");
                    return false;
                }
                
                MelonLogger.Msg($"Found component with name: {componentName}");
                return false;
            }
            catch (Exception ex)
            {
                MelonLogger.Msg($"Error fetching component {componentName} on {gameObjectName}: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Attempts to find a GameObject by name in the scene hierarchy.
        /// </summary>
        /// <param name="gameObjectName">Name of the GameObject to find.</param>
        /// <param name="gameObject">When this method returns, contains the found GameObject, or <c>null</c> if not found.</param>
        /// <returns><c>true</c> if the GameObject was found; otherwise <c>false</c>.</returns>
        public bool TryFetchGameObjectFromHierarchy(string gameObjectName, out GameObject gameObject)
        {
            gameObject = GameObject.Find(gameObjectName);
            if (gameObject == null)
            {
                MelonLogger.Msg($"No game object with name {gameObjectName} was found. Returning false + null.");
                return false;
            }
            return true;
        }
        
    }
}