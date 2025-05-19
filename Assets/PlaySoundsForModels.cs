using UnityEngine;
using Vuforia;

public class PlaySoundsForModels : MonoBehaviour
{
    public AudioSource carSound;
    public AudioSource treeSound;
    public AudioSource manSound;
    public AudioSource houseSound;

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTrackingChanged;
        }
    }

    void OnTrackingChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

        if (isTracked)
        {
            if (carSound != null && !carSound.isPlaying) carSound.Play();
            if (treeSound != null && !treeSound.isPlaying) treeSound.Play();
            if (manSound != null && !manSound.isPlaying) manSound.Play();
            if (houseSound != null && !houseSound.isPlaying) houseSound.Play();
        }
        else
        {
            if (carSound != null && carSound.isPlaying) carSound.Stop();
            if (treeSound != null && treeSound.isPlaying) treeSound.Stop();
            if (manSound != null && manSound.isPlaying) manSound.Stop();
            if (houseSound != null && houseSound.isPlaying) houseSound.Stop();
        }
    }
}
