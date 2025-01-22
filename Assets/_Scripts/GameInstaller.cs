using _Scripts.Gameplay;
using _Scripts.Gameplay.Sound;
using UnityEngine;
using Zenject;

namespace _Scripts
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Game Manager")]
        public GameManager gameManager;
        [Header("Sound Manager")]
        public SoundManager soundManager;
        [Header("Pick Up Sound")]
        public AudioClip pickUpSound;

        public override void InstallBindings()
        {
            Container.BindInstance(gameManager).AsSingle();
            Container.BindInstance(soundManager).AsSingle();
            Container.BindInstance(pickUpSound).AsSingle();
        }
    }
}