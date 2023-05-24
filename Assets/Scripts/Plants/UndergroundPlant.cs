using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundPlant : Plant
{
    [SerializeField] private GameObject nullModel;
    [SerializeField] private GameObject SproutModel;
    [SerializeField] private GameObject CropModel;

    [SerializeField] private GameObject Fruit;

    private Condition Default;
    private Condition Sprout;
    private Condition Crop;

    protected override void Growing()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime > 0.3 * GrowthTime)
            isGrowingDone = true;
    }

    protected override void InitializationCondition()
    {
        Default = new Condition(nullModel);
        Sprout = new Condition(SproutModel);
        Crop = new Condition(CropModel);

        Default.AddTransition(Tool.Types.Watering—an, Sprout);
        Sprout.AddTransition(Tool.Types.Watering—an, Crop);

        ChangeCurrentCondition(Default);
    }
}
