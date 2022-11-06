using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip pizzaCatchingSound;
    [SerializeField] private AudioClip windowBreakingSound;

    private AudioSource _audioSource;
    private void OnEnable()
    {
        Window.OnWindowBrake += WindowBreak;
        Pizza.OnPizzaCatch += PizzaCatch;
    }
    private void OnDisable()
    {
        Window.OnWindowBrake -= WindowBreak;
        Pizza.OnPizzaCatch -= PizzaCatch;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (!DataPersistance.isMusic) 
            _audioSource.Stop();
    }

    private void WindowBreak()
    {
        if(DataPersistance.isSound)
            _audioSource.PlayOneShot(windowBreakingSound);
    }

    private void PizzaCatch()
    {
        if (DataPersistance.isSound)
            _audioSource.PlayOneShot(pizzaCatchingSound);
    }
}
