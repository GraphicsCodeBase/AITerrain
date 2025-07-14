using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
    public PerlinTerrain terrain;

    public Slider widthSlider;
    public Slider heightSlider;
    public Slider scaleSlider;
    public Slider noiseScaleSlider;
    public Slider desertFrequency;
    public Slider forrestFrequency;
    public Slider plainFrequency;
    public Button generate;

    void Start()
    {
        // Initialize UI with terrain values
        widthSlider.value = terrain.width;
        heightSlider.value = terrain.height;
        scaleSlider.value = terrain.scale;
        noiseScaleSlider.value = terrain.noiseScale;

        // When sliders move, update terrain values and regenerate
        widthSlider.onValueChanged.AddListener(val =>
        {
            terrain.width = Mathf.RoundToInt(val);
        });

        heightSlider.onValueChanged.AddListener(val =>
        {
            terrain.height = Mathf.RoundToInt(val);
        });

        scaleSlider.onValueChanged.AddListener(val =>
        {
            terrain.scale = val;
        });

        noiseScaleSlider.onValueChanged.AddListener(val =>
        {
            terrain.noiseScale = val;
        });

        desertFrequency.onValueChanged.AddListener(val =>
        {
            PerlinBiome.setDesertFrequency(val);
        });

        forrestFrequency.onValueChanged.AddListener(val =>
        {
            PerlinBiome.setForestFrequency(val);
        });

        plainFrequency.onValueChanged.AddListener(val =>
        {
            PerlinBiome.setPlainFrequency(val);
        });

        generate.onClick.AddListener(() =>
        {
            terrain.GenerateTerrain();
        });

    }

}
