using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiUI.Helpers.Classes
{
    public class NotifyPropertyChangedClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetPropertyValue<T>(ref T propertyStore, T value, [CallerMemberName] string? propertyName = null, Action? onChanged = null)
        {
            if (!EqualityComparer<T>.Default.Equals(propertyStore, value))
            {
                propertyStore = value;
                onChanged?.Invoke();
                this.OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
