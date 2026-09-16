using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia;
using LissajousApp.Models;

namespace LissajousApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    //time step
    private int _dots = 100;
    public int Dots
    {
        get => _dots;
        set => SetProperty(ref _dots, value);
    }
    
    //amplitude
    private double _ax = 150;
    public double Ax
    {
        get => _ax;
        set => SetProperty(ref _ax, value);
    }
    
    private double _ay = 150;
    public double Ay
    {
        get => _ay;
        set => SetProperty(ref _ay, value);
    }
    
    //frequency
    private double? _fx = 2;
    public double? Fx
    {
        get => _fx;
        set => SetProperty(ref _fx, value);
    }
    
    private double? _fy = 3;
    public double? Fy
    {
        get => _fy;
        set => SetProperty(ref _fy, value);
    }
    
    //phase
    private double _px = 0;
    public double Px
    {
        get => _px;
        set => SetProperty(ref _px, value);
    }
    
    private double _py = 90;
    public double Py
    {
        get => _py;
        set => SetProperty(ref _py, value);
    }

    private List<Avalonia.Point> _curvePoints = new();

    public List<Avalonia.Point> CurvePoints
    {
        get => _curvePoints;
        set => SetProperty(ref _curvePoints, value);
    }

    //error handling
    private string _errorMessage = "";
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }
    
    public void GenerateCurveCommand()
    {
        if (Fx == null || Fy == null)
        {
            ErrorMessage = "Помилка: Введіть значення частоти!";
            return;
        }

        if (Fx > 100 || Fy > 100)
        {
            ErrorMessage = "Помилка! Частота не може бути більшою за 100!";
            return;
        }

        ErrorMessage = "";  //якщо все ок, ховаємо текст помилки
        
        var model = new LissajousModel(Ax, Ay, Fx.Value, Fy.Value, Px, Py);
        model.dots = Dots;  //оновлюємо кількість точок в моделі
        model.Generate();

        if (model.PointsList.Count >= 500_000)
        {
            ErrorMessage = "Увага! Досягнуто ліміт безпеки! Показано лише частину фігури.";
        }
        
        var newPoints = new List<Avalonia.Point>();
        
        double canvasWidth = 600;
        double canvasHeight = 600;

        foreach (var mathPoint in model.PointsList)
        {
            double screenX = (canvasWidth / 2.0) + mathPoint.X;
            double screenY = (canvasHeight / 2.0) - mathPoint.Y;
            newPoints.Add(new Avalonia.Point(screenX, screenY));
        }
        CurvePoints = newPoints;
    }
}
