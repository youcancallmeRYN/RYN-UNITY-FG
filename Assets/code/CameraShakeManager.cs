using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager Instance;

    [SerializeField] private CinemachineCamera cinemachineCamera;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        Instance = this;
        noise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        Reset();
    }

    public void Shake(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        //StopAllCoroutines();
        StartCoroutine(ShakeRoutine(duration));
    }

    private IEnumerator ShakeRoutine(float duration)
    {
        //noise.AmplitudeGain = intensity;

        yield return new WaitForSeconds(duration);
        Reset();

        //noise.AmplitudeGain = 0f;
    }
    void Reset()
    {
        noise.AmplitudeGain = 0f;
    }
}
