using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    internal interface ISceneHandler
    {
        void UnloadScene(string sceneName);
        void LoadScene(string sceneName, bool additive, Action<Scene> callback);
        void OnEnable();
        void OnDisable();
    }
}
