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

    public int dots = 20; //точки на найкоротший відрізок
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

    
    double CalculateSamplRate()
    {
        double maxFreq = Math.Max(freqX, freqY);

        double periodT = 1.0 / maxFreq;

        return periodT / dots;
    }
    
    
    
}
