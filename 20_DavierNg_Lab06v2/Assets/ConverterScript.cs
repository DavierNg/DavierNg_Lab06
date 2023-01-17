using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverterScript : MonoBehaviour
{
    public InputField inputAmount, inputConvertedAmount;
    public Toggle ToggleUSDollars, ToggleJapaneseYen;
    public Text DebugText;
    public float amount;
    private float result;

    float SGDUSD = 0.74f;
    float SGDJPY = 82.78f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Convert()
    {
        {
            try
            {
                float amount = float.Parse(inputAmount.text);
                if (ToggleUSDollars.isOn == true)
                {
                    result = amount * SGDUSD;
                    DebugText.GetComponent<Text>().text = result.ToString();
                    inputConvertedAmount.text = "$" + result.ToString();
                    ToggleJapaneseYen.isOn = false;
                }
                if (ToggleJapaneseYen.isOn == true)
                {
                    result = amount * SGDJPY;
                    DebugText.GetComponent<Text>().text = result.ToString();
                    inputConvertedAmount.text = result.ToString() + " Yen";
                    ToggleUSDollars.isOn = false;
                }
            }
            catch (System.FormatException e)
            {
                DebugText.GetComponent<Text>().text = "Please type in numbers";
            }
        }
    }

    public void Clear()
    {
        result = 0;
        amount = 0;
        DebugText.text = "Debug Text";
        inputConvertedAmount.text = "0";
        ToggleJapaneseYen.isOn = false;
        ToggleUSDollars.isOn = false;
    }
}
