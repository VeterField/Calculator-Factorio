using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : DataBase
{
    private List<ReportLine> _reportList = new List<ReportLine>();

    public void TryAddLine(in RecipeName name, in IndustryName type)
    {
        for (int i = 0; i < _reportList.Count; i++)
        {
            if (_reportList[i].Name == name)
            {
                return;
            }
        }

        _reportList.Add(new ReportLine(name, type));
    }

    public void TryAddLine(in RecipeName name, in IndustryName type, in float factory, in float output, in float amount, in float polution, in float energy)
    {
        for (int i = 0; i < _reportList.Count; i++)
        {
            if (_reportList[i].Name == name)
            {
                return;
            }
        }

        _reportList.Add(new ReportLine(name, type, factory, output, amount, polution, energy));
    }

    public void TryAddValues(in RecipeName name, in float factory, in float output, in float amount, in float polution, in float energy)
    {
        if (_reportList.Count > 0)
        {
            for (int i = 0; i < _reportList.Count; i++)
            {
                if (name == _reportList[i].Name)
                {
                    _reportList[i].AddValues(factory, output, amount, polution, energy);

                    return;
                }
            }
        }
    }

    public void ShowReport()
    {
        if (_reportList.Count > 0)
        {
            for (int i = 0; i < _reportList.Count; i++)
            {
                _reportList[i].ShowLineData();
            }
        }
    }

    public ReportLine TryGetReportLine(in RecipeName name)
    {
        for (int i = 0; i < _reportList.Count; i++)
        {
            if (_reportList[i].Name == name)
            {
                return _reportList[i];
            }
        }
        return new ReportLine(RecipeName.Null, IndustryName.Null);
    }
}

public class ReportLine : ReportLinePattern
{
    public override RecipeName Name { get; private protected set; }
    public override IndustryName IndustryType { get; private protected set; }
    public override float FactoryAmount { get; private protected set; }
    public override float FactoryOutput { get; private protected set; }
    public override float BeltAmount { get; private protected set; }
    public override float TotalPolution { get; private protected set; }
    public override float TotalEnergyConsamption { get; private protected set; }

    public ReportLine(in RecipeName name, in IndustryName type)
    {
        Name = name;
        IndustryType = type;
        FactoryAmount = 0;
        FactoryOutput = 0;
        BeltAmount = 0;
        TotalPolution = 0;
        TotalEnergyConsamption = 0;
    }

    public ReportLine(in RecipeName name, in IndustryName type, in float factory, in float output, in float amount, in float polution, in float energy)
    {
        Name = name;
        IndustryType = type;
        FactoryAmount = factory;
        FactoryOutput = output;
        BeltAmount = amount;
        TotalPolution = polution;
        TotalEnergyConsamption = energy;
    }

    public void AddValues(in float factory, in float output, in float amount, in float polution, in float energy)
    {
        FactoryAmount += factory;
        FactoryOutput += output;
        BeltAmount += amount;
        TotalPolution += polution;
        TotalEnergyConsamption += energy;
    }

    public void TryChageNullIndustry(in IndustryName newType)
    {
        if (IndustryType == IndustryName.Null)
        {
            IndustryType = newType;
        }
    }

    public void ShowLineData()
    {
        Debug.Log(Name + " " + IndustryType + " Factory " + FactoryAmount + " Output " + FactoryOutput + " Belts " + BeltAmount + " Polution " + TotalPolution + " Energy " + TotalEnergyConsamption);
    }
}
