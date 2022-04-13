using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Game : MonoSingleton<Game>
{
    public event Action OnGame;
    public event Action EndGame;
    public event Action ReStartGame;
    [SerializeField] private AudioClip successSFX;

    
    public GameStatus gameStatus = GameStatus.Ready;
    public bool isSuccess = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void StartGame()
    {
        gameStatus = GameStatus.OnGame;
        OnGame?.Invoke();
        isSuccess = false;
        audioSource.Play();        
    }

    public void GameOver()
    {
        gameStatus = GameStatus.GameOver;
        EndGame?.Invoke();
        audioSource.Stop();
    }

    public void ReStart()
    {
        StartGame();
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    
    public void ClearGame()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        gameStatus = GameStatus.GameClear;
        StartCoroutine(QuitApplication());
    }

    IEnumerator QuitApplication()
    {
        yield return new WaitForSeconds(5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
