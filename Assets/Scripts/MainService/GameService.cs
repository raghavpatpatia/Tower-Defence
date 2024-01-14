using ServiceLocator.Player;
using ServiceLocator.Utilities;
using ServiceLocator.Events;
using UnityEngine;
using ServiceLocator.Map;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Wave;

public class GameService : GenericMonoSingleton<GameService>
{
    // Player Service
    [Header("Player Service")]
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    public PlayerService playerService { get; private set; }

    // Map Service
    [Header("Map Service")]
    [SerializeField] private MapScriptableObject mapScriptableObject;
    public MapService mapService { get; private set; }

    // Sound Service
    [Header("Sound Service")]
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    public SoundService soundService { get; private set; }

    // UI Service
    [Header("UI Service")]
    [SerializeField] private UIService uiService;
    public UIService UIservice => uiService;

    // Wave Service
    [Header("Wave Service")]
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    public WaveService waveService { get; private set; }

    // Event Service
    public EventService eventService { get; private set; }

    private void Start()
    {
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        eventService = new EventService();
        waveService = new WaveService(waveScriptableObject);
        mapService = new MapService(mapScriptableObject);
        playerService = new PlayerService(playerScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}