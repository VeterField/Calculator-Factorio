using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private readonly RecipeBook _recipeBook = new RecipeBook();
    private readonly IndustryBook _industryBook = new IndustryBook();
    private Report _reportList = new Report();
    private readonly Math _math = new Math();

    private RecipeName _inputName = RecipeName.PlasticBar;
    private int _targetOutput = 200;

    private void Awake()
    {
        Calculate(_inputName, _targetOutput);

        _reportList.ShowReport();
    }

    private void Calculate(in RecipeName name, in float targetValue)
    {
        SetNextStep(name, targetValue);

        CountOilFactory(RecipeName.BaseOilProcesing);
    }

    private void SetNextStep(in RecipeName name, in float targetValue)
    {
        if (_recipeBook.GetRecipe(name, out var recipe) == true)
        {
            TryAddAndFillReportLine(recipe, targetValue);

            TryMakeNextStepAndCountCost(recipe, targetValue);
        }
    }

    private void TryAddAndFillReportLine(in Recipe recipe, in float targetValue)
    {
        if (recipe._productList.Count > 0)
        {
            for (int i = 0; i < recipe._productList.Count; i++)
            {
                _reportList.TryAddLine(recipe._productList[i].name, recipe.IndustryType);

                _math.TryCountFactoryAmount(targetValue, recipe, out var factory);

                float belts = 0;
                if (recipe.IndustryType != IndustryName.Null)
                {
                    _math.CountBeltAmount(targetValue, out belts);
                }

                _math.TryCountTotalPolution(factory, recipe, out var polution);
                _math.TryCountTotalEnergyConsumption(factory, recipe, out var energy);

                _reportList.TryAddValues(recipe._productList[i].name, factory, targetValue, belts, polution, energy);
            }
        }
    }

    private void TryMakeNextStepAndCountCost(in Recipe recipe, in float targetValue)
    {
        if (recipe._costList.Count > 0)
        {
            _math.TryCountFactoryAmount(targetValue, recipe, out var factory);

            for (int i = 0; i < recipe._costList.Count; i++)
            {
                _math.TryCountFactoryOutput(factory, recipe, i, out var newTargetValue);

                SetNextStep(recipe._costList[i].name, newTargetValue);
            }
        }
    }

    private void CountOilFactory(in RecipeName OilProcesName)
    {
        GetOilNeeds(out float[] _needs);

        if (OilProcesName == RecipeName.BaseOilProcesing)
        {
            if (_recipeBook.GetRecipe(RecipeName.BaseOilProcesing, out Recipe recipe) == true)
            {
                var reportLine = _reportList.TryGetReportLine(RecipeName.PetroliumGas);

                reportLine.TryChageNullIndustry(IndustryName.OilRefinery);

                _math.TryCountFactoryAmount(_needs[2], recipe, out float factory);
                _math.TryCountTotalPolution(factory, recipe, out float polution);
                _math.TryCountTotalEnergyConsumption(factory, recipe, out float energy);

                reportLine.AddValues(factory, 0, 0, polution, energy);
            }
        }
    }

    private void GetOilNeeds(out float[] needs)
    {
        needs = new float[3];

        needs[0] = _reportList.TryGetReportLine(RecipeName.HeavyOil).FactoryOutput;
        needs[1] = _reportList.TryGetReportLine(RecipeName.LightOil).FactoryOutput;
        needs[2] = _reportList.TryGetReportLine(RecipeName.PetroliumGas).FactoryOutput;
    }
}