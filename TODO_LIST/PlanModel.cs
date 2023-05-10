using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TODO_LIST;
public class PlanModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string _description;
    private int _quanitity;
    private bool _isDone;
    //private FontAttributes _fontAttributes;
    
    /*public TextDecorations TextDecorations => IsDone ? TextDecorations.Strikethrough : TextDecorations.None;*/
    public bool IsDone { get { return _isDone; }
        set
        {
            if (_isDone != value)
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
                OnPropertyChanged(nameof(TextDecorations));
            }
        }
    }

    public int Quantity
    {
        get { return _quanitity;}
        set
        {
            if (_quanitity != value)
            {
                _quanitity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    public string Description
    {
        get { return _description; }
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
    public PlanModel()
    {

    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
