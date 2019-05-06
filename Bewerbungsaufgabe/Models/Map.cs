using Bewerbungsaufgabe.Models;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Bewerbungsaufgabe.Models
{

    /// <summary>
    /// Map extends all of a dictionary. TKey is a MeasurementType for
    /// temperature TEMP or spo2 SPO2.
    /// </summary>
    /// <typeparam name="TKey">MeasuremnetType</typeparam>
    /// <typeparam name="TValue">List<Measurement></typeparam>
    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Serializable]
    public class Map<TKey, TValue> : Dictionary<TKey, TValue> 
    { 
    }
}