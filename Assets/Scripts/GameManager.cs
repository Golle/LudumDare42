using Assets.Scripts.EventSystem.Events;
using Assets.Scripts.Framework.Input;
using Assets.Scripts.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
#pragma warning disable 649

namespace Assets.Scripts
{
    public class GameManager : BehaviourBase
    {
        [SerializeField]
        private Texture2D _cursor;

        [SerializeField]
        private string _hudSceneName;
        [SerializeField]
        private string _gameSceneName;

        [SerializeField]
        private string _startupSceneName;

        private ISceneHandler _sceneHandler;
        private IInputHandler _inputHandler;
        private bool _startupLoaded;
        private Scene _startupScene;
        private Scene _hudScene;
        private Scene _gameScene;

        void Awake()
        {
            _sceneHandler = GetInstance<ISceneHandler>();
            _inputHandler = GetInstance<IInputHandler>();
            Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
        }

        void Start()
        {
            ShowStartupScreen();
        }

        private void ShowStartupScreen()
        {
            _sceneHandler.LoadScene(_startupSceneName, true, scene =>
            {
                _startupScene = scene;
                _startupLoaded = true;
            });
        }


        void Update()
        {
            if (!_startupLoaded)
            {
                return;
            }

            if (_inputHandler.Escape)
            {
                Application.Quit();
            }
            if (_inputHandler.Space)
            {
                _startupLoaded = false;
                DisableScene(ref _startupScene);
                _sceneHandler.UnloadScene(_startupSceneName);
                _sceneHandler.LoadScene(_hudSceneName, true, scene => _hudScene = scene);
                _sceneHandler.LoadScene(_gameSceneName, true, scene =>
                {
                    _gameScene = scene;
                    RaiseEvent(new GameStartedEvent());
                });
            }
            
        }
        
        void OnEnable()
        {
            _sceneHandler.OnEnable();
            Subscribe<GameFinishedEvent>(OnGameFinished);
        }

        void OnDisable()
        {
            Unsubscribe<GameFinishedEvent>(OnGameFinished);
            _sceneHandler.OnDisable();
        }

        private void OnGameFinished(GameFinishedEvent obj)
        {
            DisableScene(ref _gameScene);
            _sceneHandler.UnloadScene(_gameSceneName);
            DisableScene(ref _hudScene);
            _sceneHandler.UnloadScene(_hudSceneName);

            ShowStartupScreen();
        }

        private static void DisableScene(ref Scene scene)
        {
            foreach (var rootGameObject in scene.GetRootGameObjects())
            {
                rootGameObject.SetActive(false);
            }
        }
    }
}