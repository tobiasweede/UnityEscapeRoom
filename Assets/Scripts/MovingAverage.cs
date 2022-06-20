using System.Collections;
using System.Collections.Generic;
using System;

public class MovingAverage  
{
    private Queue<float> samples = new Queue<float>();
    private int windowSize = 16;
    private float sampleAccumulator;
    public float Average { get; private set; }

    /// <summary>
    /// Computes a new windowed average each time a new sample arrives
    /// </summary>
    /// <param name="newSample"></param>
    public void ComputeAverage(float newSample)
    {
        sampleAccumulator += newSample;
        samples.Enqueue(newSample);

        if (samples.Count > windowSize)
        {
            sampleAccumulator -= samples.Dequeue();
        }

        Average = sampleAccumulator / samples.Count;
    }
}