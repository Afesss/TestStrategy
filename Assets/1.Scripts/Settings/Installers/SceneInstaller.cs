using App.Factory;
using App.Player;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private ProductPool _productPool;
    public override void InstallBindings()
    {
        Container.BindInstance(_player).AsSingle();
        Container.BindInstance(_productPool).AsSingle();
    }
}