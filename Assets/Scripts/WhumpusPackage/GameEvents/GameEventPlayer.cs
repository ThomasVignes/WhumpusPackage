using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Whumpus;

public class GameEventPlayer : MonoBehaviour
{
    [Header("Conditions")]
    public bool PlayOnce;
    [SerializeField] private float playDelay;
    public bool PlayOnStart, PlayOnTriggerEnter, PlayOnCollision;
    [SerializeField] private GameObject player;
    

    [Header("Event Settings")]
    public string EventName;
    [SerializeField] private GameObject gameobject;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private UnityEvent delegates;

    private bool played;
    private Coroutine playedEvent;

    private void Start()
    {
        if (PlayOnStart)
        {
            PlayEvent();
        }
    }

    public void PlayEvent()
    {
        if (playedEvent != null)
            StopCoroutine(playedEvent);

        StartCoroutine(PlayerEventCoroutine());
    }

    private IEnumerator PlayerEventCoroutine()
    {
        yield return new WaitForSecondsRealtime(playDelay);

        if (!played)
            GameEventsManager.PlayEvent(EventName, gameobject, animator, audioSource, delegates);

        if (PlayOnce)
            played = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayOnTriggerEnter && other.gameObject == player)
        {
            PlayEvent();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayOnTriggerEnter && collision.gameObject == player)
        {
            PlayEvent();
        }
    }
}
