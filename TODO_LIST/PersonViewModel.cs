using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Android.Util;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Org.Apache.Http.Protocol;

namespace TODO_LIST;

public sealed class PersonViewModel : INotifyPropertyChanged
{
    public ObservableCollection<PlanModel> _planList = new ObservableCollection<PlanModel>();

    public ICommand AddCommand { get;}
    public ICommand DeleteCommand { get; }
    public ObservableCollection<PlanModel> PlanList
    {
        get { return _planList; }
        set
        {
            if (_planList != value)
            {
                _planList = value;
                OnPropertyChanged(nameof(PlanList));
            }
        }
    }

    public PersonViewModel()
    {
        AddCommand = new Command<string>(s =>
        {
            if (!string.IsNullOrEmpty(s)) 
            {
                var parts = s.Split(':');
                if (parts.Length == 2)
                {
                    if (parts[1] == "")
                    {
                        int quantity = 1;
                        var current = new PlanModel() { Description = parts[0], Quantity = quantity };
                        PlanList.Add(current);
                    }
                    else
                    {
                        int quantity = int.Parse(parts[1]);
                        var current = new PlanModel() { Description = parts[0], Quantity = quantity };
                        PlanList.Add(current);
                    }
                }
                else
                {
                    int quantity = 1;
                    var current = new PlanModel() { Description = parts[0], Quantity = quantity };
                    PlanList.Add(current);
                }
            }
        });
        DeleteCommand = new Command<PlanModel>(s =>
            {
                if(s != null) {PlanList.Remove(s);}
            }
        );
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


