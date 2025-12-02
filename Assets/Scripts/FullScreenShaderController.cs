using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullScreenShaderController : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] private float _hurtDisplayTime = 1.5f;
    [SerializeField] private float _hurtFadeOutTime = 0.5f;

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _fullScreenDamage;
    [SerializeField] private Material _material;

    [Header("Intensity Stats")]
    [SerializeField] private float _voronoIntensityStat = 2.5f;
    [SerializeField] private float _vigentteIntensityStat = 1.25f;

    private int _voronoIntensity = Shader.PropertyToID("_VoronoiIntenisty");
    private int _vigentteIntensity = Shader.PropertyToID("_VignetteIntensity");

    /*private const float VORONOI_INTENSITY_START_AMOUNT = 2.5F;
    private const float VIGETTE_INTENSITY_START_AMOUNT = 1.25F; */

    private void Start()
    {
        _fullScreenDamage.SetActive(false);
    }

    public void StartFreeze()
    {
        StartCoroutine(Hurt());
    }
        

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(Hurt());
        }

        
    }

    private IEnumerator Hurt()
    {
        _fullScreenDamage.SetActive(enabled);
        _material.SetFloat(_voronoIntensity, _voronoIntensityStat);
        _material.SetFloat(_vigentteIntensity, _vigentteIntensityStat);

        yield return new WaitForSeconds(_hurtDisplayTime);

        float eLapsedTime = 0f;
        while(eLapsedTime < _hurtFadeOutTime)
        {
            eLapsedTime += Time.deltaTime;

            float lerpedVoronoi = Mathf.Lerp(_voronoIntensityStat, 0F, (eLapsedTime / _hurtFadeOutTime));
            float lerpedVigentte = Mathf.Lerp(_vigentteIntensityStat, 0F, (eLapsedTime / _hurtFadeOutTime));

            _material.SetFloat(_voronoIntensity, lerpedVoronoi);
            _material.SetFloat(_vigentteIntensity, lerpedVigentte);

            yield return null;
        }

        _fullScreenDamage.SetActive(false);
    }



}

