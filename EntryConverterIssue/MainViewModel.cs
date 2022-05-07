using System;

namespace EntryConverterIssue.ViewModel;

public class MainViewModel : ObservableObject
{
    double subtotalBill = 0;
    public double SubtotalBill
    {
        get => subtotalBill;
        set
        {
            SetProperty(ref subtotalBill, value, raisePropertyChangedOnUnchangedValues: true);
            CalculateTip();
        }
    }

    double percentageTip = 0.15;
    public double PercentageTip
    {
        get => percentageTip;
        set
        {
            SetProperty(ref percentageTip, Math.Round(value, 2));
            CalculateTip();
        }
    }

    double totalTip = 0;
    public double TotalTip
    {
        get => totalTip;
        set
        {
            SetProperty(ref totalTip, value);
            OnPropertyChanged(nameof(TotalBill));
        }
    }

    public double TotalBill => SubtotalBill + TotalTip;

    public MainViewModel()
    {
    }

    double CalculateTip() => TotalTip = SubtotalBill * PercentageTip;
}
