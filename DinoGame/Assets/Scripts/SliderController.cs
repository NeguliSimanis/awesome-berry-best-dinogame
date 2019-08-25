using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    private Slider HPslider;
    private Slider CrateSlider;
    private Slider HumanSlider;
    private CharacterHealth health;
    private GameController score;
    private BaseController humanScore;
    // Start is called before the first frame update
    void Start()
    {
        HPslider = GameObject.Find("HPslider").GetComponent<Slider>();
        CrateSlider = GameObject.Find("CrateSlider").GetComponent<Slider>();
        HumanSlider = GameObject.Find("HumanSlider").GetComponent<Slider>();
        health = GameObject.Find("DinosaurPlayer").GetComponent<CharacterHealth>();
        score = GameObject.Find("GameController").GetComponent<GameController>();
        humanScore = GameObject.Find("HumanBase").GetComponent<BaseController>();
    }

    // Update is called once per frame
    void Update()
    {
        HPslider.value = health.health / 100;
        CrateSlider.value = score.score / 10;
        HumanSlider.value = humanScore.points / 10;
    }
}
