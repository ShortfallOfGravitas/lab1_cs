using System;
using System.Collections.Generic;

namespace LissajousApp.Models;

public struct Coordinate
{
    public double X { get; set }    //треба розібратись
    public double Y {get; set; }

    public Coordinate(double x, double y)
    {
        X = x;
        Y = y;
    }
}


public class LissajousModel()
{
    public List<Coordinate> PointsList = new List<Coordinate>(); //array with coordinates
    private Stack<List<Coordinate>> history = new Stack<List<Coordinate>>();
    
    private double t;   //час у симуляції
    private double Dt;  // delta t (sampling rate, інтервал дискретизації) 
    
    //amplitude
    private double Ax;
    private double Ay;
    
    //frequency
    private double fx;
    private double fy;
    
    //phase
    private double px;
    private double py;

    
    CalculateSamplRate()
    {
        
    }
}
