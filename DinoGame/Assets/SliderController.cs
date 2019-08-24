using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    private Slider HPslider;
    private Slider CrateSlider;
    private CharacterHealth health;
    private GameController score;
    // Start is called before the first frame update
    void Start()
    {
        HPslider = GameObject.Find("HPslider").GetComponent<Slider>();
        CrateSlider = GameObject.Find("CrateSlider").GetComponent<Slider>();
        health = GameObject.Find("DinosaurPlayer").GetComponent<CharacterHealth>();
        score = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        HPslider.value = health._health / 100;
        CrateSlider.value = score.score / 10;
    }
}
