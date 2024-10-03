using TMPro;
using UnityEngine;

public class HeighMeterController : MonoBehaviour
{
    private int height;
    public TextMeshProUGUI textMesh;

    void Update()
    {
        //about 140 seconds to the top. at 7.5 per second it reaches 1000m at the top
        height = Mathf.RoundToInt(Time.timeSinceLevelLoad * 7.5f);
        textMesh.text = height.ToString() + "M";
    }
}
