using UnityEngine;

namespace Assets.Scripts.Character
{
    internal class GameTime : IGameTime
    {
        public float DeltaTime => Time.deltaTime;
    }
}