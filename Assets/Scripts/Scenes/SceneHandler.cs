using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    internal class SceneHandler : ISceneHandler
    {
        private readonly IDictionary<string, Action<Scene>> _callbacks = new ConcurrentDictionary<string, Action<Scene>>(StringComparer.OrdinalIgnoreCase);

        public void OnEnable()
        {
            SceneManager.sceneLoaded += SceneLoaded;
            SceneManager.sceneUnloaded += SceneUnloaded;
        }

        public void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            SceneManager.sceneUnloaded -= SceneUnloaded;
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void LoadScene(string sceneName, bool additive, Action<Scene> callback)
        {
            var mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
            if (additive)
            {
                _callbacks.Add(sceneName, callback);
            }
            SceneManager.LoadSceneAsync(sceneName, mode);
        }

        private void SceneUnloaded(Scene scene)
        {
            Debug.Log($"Scene unloaded '{scene.name}'");
        }


        private void SceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            Action<Scene> callback;
            if (_callbacks.TryGetValue(scene.name, out callback))
            {
                callback(scene);
                _callbacks.Remove(scene.name);
            }
            else
            {
                Debug.Log($"Failed to find callback for '{scene.name}'");
            }
        }
    }
}