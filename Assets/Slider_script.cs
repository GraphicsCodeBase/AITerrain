using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
    public PerlinTerrain terrain;

    public Slider widthSlider;
    public Slider heightSlider;
    public Slider scaleSlider;
    public Slider noiseScaleSlider;

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
            terrain.GenerateTerrain();
        });

        heightSlider.onValueChanged.AddListener(val =>
        {
            terrain.height = Mathf.RoundToInt(val);
            terrain.GenerateTerrain();
        });

        scaleSlider.onValueChanged.AddListener(val =>
        {
            terrain.scale = val;
            terrain.GenerateTerrain();
        });

        noiseScaleSlider.onValueChanged.AddListener(val =>
        {
            terrain.noiseScale = val;
            terrain.GenerateTerrain();
        });
    }

}
