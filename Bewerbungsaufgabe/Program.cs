using Bewerbungsaufgabe.Models;
using System;
using System.Collections.Generic;

namespace Bewerbungsaufgabe
{

    /// <summary>
    /// This program samples values of measurements.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main method begins the sampling program
        /// </summary>
        /// <param name="args">command line args as string[] array.</param>
        static void Main(string[] args)
        {
            Instant startOfSampling = new Instant();
            Sampling sampling = new Sampling();
            startOfSampling.Time = DateTime.Parse("2017-01-03T10:00:00");
            List<Measurement> unsampleMeasurementsList = sampling.CreateSamples();
            Map<MeasurementType, List<Measurement>> map =
                sampling.Sample(startOfSampling, unsampleMeasurementsList);

            // Writes unsampled input top display.
            Console.WriteLine("INPUT:");
            for(int i = 0; i <unsampleMeasurementsList.Count; i++)
            {
                Console.WriteLine(unsampleMeasurementsList[i]);
            }

            // Outputs sampled measurments to display.
            Console.WriteLine("OUTPUT:");
            foreach (KeyValuePair<MeasurementType,
                List<Measurement>> keyValuePair in map)
            {
                foreach(Measurement sampledMeasurement in keyValuePair.Value)
                {
                    Console.WriteLine(sampledMeasurement);
                }
            }

            // To pause I used ReadKey.
            Console.ReadKey();
        }
    }
}
