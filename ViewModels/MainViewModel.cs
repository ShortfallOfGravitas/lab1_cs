using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia;
using LissajousApp.Models;

namespace LissajousApp.ViewModels;

public class MainViewModel : ViewModelBase
{
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
    private double _fx = 2;
    public double Fx
    {
        get => _fx;
        set => SetProperty(ref _fx, value);
    }
    
    private double _fy = 3;
    public double Fy
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

    public void GenerateCurveCommand()
    {
        var model = new LissajousModel(Ax, Ay, Fx, Fy, Px, Py);
        model.Generate();

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
