using System;
using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hero;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float openDelay;
    [SerializeField] private float forceJump;

    public Action OnOpen;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(openDelay);
        Open();
        yield return new WaitForSeconds(spawnDelay);
        SpawnHero();
    }

    private void Open()
    {
        OnOpen?.Invoke();
    }

    private void SpawnHero()
    {
        hero.transform.position = transform.position;
        hero.AddForce(Vector2.one * forceJump,ForceMode2D.Impulse);
    }
}
