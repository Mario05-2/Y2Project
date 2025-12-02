using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullScreenTestController : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] private float _hurtDisplayTime = 1.5f;
    [SerializeField] private float _hurtFadeOutTime = 0.5f;

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _fullScreenDamage;
    [SerializeField] private Material _material;

    private int voronoIntensity = Shader.PropertyToID("_VoronoiIntenisty");
    private int vigentteIntensity = Shader.PropertyToID("_VignetteIntensity");

    private const float VORONOI_INTENSITY_START_AMOUNT = 1.25F;
    private const float VIGETTE_INTENSITY_START_AMOUNT = 1.25F;

    private void Start()
    {
        _fullScreenDamage.SetActive(false);
    }



}
