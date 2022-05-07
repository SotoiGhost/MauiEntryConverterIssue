using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EntryConverterIssue.ViewModel;

public class ObservableObject : INotifyPropertyChanged
{
    //
    // Summary:
    //     Occurs when property changed.
    public event PropertyChangedEventHandler PropertyChanged;

    //
    // Summary:
    //     Sets the property.
    //
    // Parameters:
    //   backingStore:
    //     Backing store.
    //
    //   value:
    //     Value.
    //
    //   validateValue:
    //     Validates value.
    //
    //   propertyName:
    //     Property name.
    //
    //   onChanged:
    //     On changed.
    //
    // Type parameters:
    //   T:
    //     The 1st type parameter.
    //
    // Returns:
    //     true, if property was set, false otherwise.
    protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null, Func<T, T, bool> validateValue = null, bool raisePropertyChangedOnUnchangedValues = false)
    {
        //if value didn't change
        if (EqualityComparer<T>.Default.Equals(backingStore, value) && !raisePropertyChangedOnUnchangedValues)
            return false;

        if (validateValue != null && !validateValue!(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    //
    // Summary:
    //     Raises the property changed event.
    //
    // Parameters:
    //   propertyName:
    //     Property name.
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
