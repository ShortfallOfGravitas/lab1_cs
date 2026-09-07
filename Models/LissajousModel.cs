using System;
using System.Collections.Generic;

namespace LissajousApp.Models;

public readonly struct Coordinate(double x, double y)
{
    public double X { get; } = X;   //треба розібратись
    public double Y { get; } = Y;
}


public class LissajousModel(double amplX, double amplY, 
                            double freqX, double freqY, 
                            double phX, double phY)
{
    public List<Coordinate> PointsList = new List<Coordinate>(); //array with coordinates
    private Stack<List<Coordinate>> history = new Stack<List<Coordinate>>();

    private int dots = 20; //точки на найкоротший відрізок
    private double t;   //час у симуляції
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

    
    CalculateSamplRate(a, b)
    {
        double maxFreq = Math.Max(a, b);

        double periodT = 1.0 / maxFreq;

        return double deltaT = periodT / dots;
    }
}
