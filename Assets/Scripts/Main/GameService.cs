using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Sound;
using ServiceLocator.Player;
using ServiceLocator.UI;

namespace ServiceLocator.Main
{
    public class GameService : MonoBehaviour
    {
        // Services:
        private EventService eventService;
        private MapService mapService;
        private WaveService waveService;
        private SoundService soundService;
        private PlayerService playerService;

        [SerializeField] private UIService uiService;


        // Scriptable Objects:
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        // Scene Referneces:
        [SerializeField] private AudioSource SFXSource;
        [SerializeField] private AudioSource BGSource;

        private void Start()
        {
            InitializeServices();
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            playerService.Init(uiService, mapService, soundService);
            uiService.Init(eventService, waveService, playerService);
            mapService.Init(eventService);
            waveService.Init(eventService, uiService, mapService, soundService, playerService);
        }

        private void InitializeServices()
        {
            eventService = new EventService();
            mapService = new MapService(mapScriptableObject);
            waveService = new WaveService(waveScriptableObject);
            soundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
            playerService = new PlayerService(playerScriptableObject);
        }

        private void Update()
        {
            playerService.Update();
        }
    }
}