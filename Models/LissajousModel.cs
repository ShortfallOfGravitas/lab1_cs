using System;
using System.Collections.Generic;

namespace LissajousApp.Models;

public readonly struct Coordinate(double x, double y)
{
    public double X { get; } = x;   //треба розібратись
    public double Y { get; } = y;
}


public class LissajousModel(double amplX, double amplY, 
                            double freqX, double freqY, 
                            double phX, double phY)
{
    public List<Coordinate> PointsList = new List<Coordinate>(); //array with coordinates
    private Stack<List<Coordinate>> history = new Stack<List<Coordinate>>();

    public int dots; //точки на найкоротший відрізок
    // private double t;   //час у симуляції онлі всередині for
    private double Dt;  // delta t (sampling rate, інтервал дискретизації) 
    
    //amplitude
    private double Ax = amplX;
    private double Ay  = amplY;
    
    //frequency
    private double fx = freqX;
    private double fy = freqY;
    
    //phase
    private double px  = phX;
    private double py = phY;

    
    private double CalculateSamplRate()
    {
        double maxFreq = Math.Max(fx, fy);

        double periodT = 1.0 / maxFreq;

        return (periodT / dots);
    }

    public void Generate()
    {
        if (PointsList.Count > 0)
        {
            history.Push(PointsList);
        }

        PointsList = new List<Coordinate>();
        
        Dt = CalculateSamplRate();
        double tmax = 10.0;     //максимальний час симуляції

        double pxRad = px * Math.PI / 180.0;    //переведення у радіани
        double pyRad = py * Math.PI / 180.0;

        double omegaX = 2 * Math.PI * fx;   //кутова швидкість константна, тож виносимо за межі циклу
        double omegaY = 2 * Math.PI * fy;
        
        for (double t = 0; t <= tmax; t += Dt)
        {
            double currentX = Ax * Math.Sin(omegaX * t + pxRad);
            double currentY = Ay * Math.Sin(omegaY * t + pyRad);
            
            Coordinate point = new Coordinate(currentX, currentY);
            PointsList.Add(point);
        }
    }
}