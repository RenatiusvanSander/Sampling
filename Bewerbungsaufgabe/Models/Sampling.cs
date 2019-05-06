using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbungsaufgabe.Models
{

    /// <summary>
    /// Unsampled samples are sample here. One value of a time frame is taken
    /// and stored in a list. Temperature and spo2 are sampled on their own.
    /// </summary>
    public class Sampling
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public Sampling() { }

        /// <summary>
        /// Creates the measurement data as array. Array size is 7 fields.
        /// For Unit test method is set to public.
        /// </summary>
        /// <returns>Returns an array of Measurement samples.</returns>
        public List<Measurement> CreateSamples()
        {
            List<Measurement> measurementsList = new List<Measurement>();
            Measurement[] measurementsArray = new Measurement[7];

            // Creates measurementsArray and fills values.
            measurementsArray[0] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:04:45") },
                MeasurementValue = 35.79,
                Type = MeasurementType.TEMP
            };
            measurementsArray[1] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:01:18") },
                MeasurementValue = 98.78,
                Type = MeasurementType.SPO2
            };
            measurementsArray[2] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:09:07") },
                MeasurementValue = 35.01,
                Type = MeasurementType.TEMP
            };
            measurementsArray[3] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:03:34") },
                MeasurementValue = 96.49,
                Type = MeasurementType.SPO2
            };
            measurementsArray[4] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:02:01") },
                MeasurementValue = 35.82,
                Type = MeasurementType.TEMP
            };
            measurementsArray[5] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 97.17,
                Type = MeasurementType.SPO2
            };
            measurementsArray[6] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:01") },
                MeasurementValue = 95.08,
                Type = MeasurementType.SPO2
            };

            // Adds all measurementsArray elements to measurmentsList.
            foreach (Measurement measurement in measurementsArray)
            {
                measurementsList.Add(measurement);
            }

            return measurementsList;
        }

        /// <summary>
        /// This medthod samples temperature and heartbeat (spo2). The time
        /// frame is 5 minutes. Only one sample is taken for 5 minutes.
        /// </summary>
        /// <param name="startOfSampling">Instant contains a start sampling time.</param>
        /// <param name="unsampledMeasurements">A list of measurements are
        /// unsampled and are going to be sampled.</param>
        /// <returns>A Map as dictionary with sampled values.</returns>
        public Map<MeasurementType, List<Measurement>> Sample(Instant startOfSampling,
            List<Measurement> unsampledMeasurements)
        {
            List<Measurement> temperatureSamplesList = new List<Measurement>();
            List<Measurement> spo2SamplesList = new List<Measurement>();
            List<Measurement>[] ListsArray = CreateLists(unsampledMeasurements);
            Map<MeasurementType, List<Measurement>> measurementMap = new Map<MeasurementType, List<Measurement>>();

            // Copies lists temperatureSamplesList and spo2SamplesList
            temperatureSamplesList = ListsArray[0];
            spo2SamplesList = ListsArray[1];

            // Sorts and samples temperature and spo2.
            temperatureSamplesList = SampledMeasurementList(startOfSampling, temperatureSamplesList);
            spo2SamplesList = SampledMeasurementList(startOfSampling, spo2SamplesList);

            // Adds the temperature and spo2 lists to measurementMap.
            measurementMap.Add(MeasurementType.TEMP, temperatureSamplesList);
            measurementMap.Add(MeasurementType.SPO2, spo2SamplesList);

            return measurementMap;
        }

        /// <summary>
        /// This method divides the unsampled measurements into two
        /// independent lists of temperature and spo2. It returns an
        /// array of Measurements list with 2 firelds.
        /// </summary>
        /// <param name="unsampledMeasurements">List<Measurement> A unsampled measurements are
        /// divide in two list of temperature and spo2. They are returned as
        /// an array of lists</param>
        /// <returns>List<Measurement>[]</returns>
        public List<Measurement>[] CreateLists(List<Measurement> unsampledMeasurements)
        {
            List<Measurement> temperatureSamplesList = new List<Measurement>();
            List<Measurement> spo2SamplesList = new List<Measurement>();
            List<Measurement>[] listsArray = new List<Measurement>[2];

            // Copy measurements into list by Measurment.Type. Here is
            // differenced between temperature and spo2.
            foreach (Measurement measurement in unsampledMeasurements)
            {
                switch (measurement.Type)
                {

                    // Adds temperature values to temporateTempList.
                    case MeasurementType.TEMP:
                        temperatureSamplesList.Add(measurement);
                        break;

                    // Adds SPO2 values to temporateSPO2List.
                    case MeasurementType.SPO2:
                        spo2SamplesList.Add(measurement);
                        break;
                }
            }

            // Copies unsampled lists to listsArray.
            listsArray[0] = temperatureSamplesList;
            listsArray[1] = spo2SamplesList;

            // Outputs the lists are empty and throw exception.
            if (listsArray[0] == null || listsArray[1] == null)
            {
                Console.WriteLine("Error: Unsampled lists are empty. Please fill them.");
                throw new Exception();
            }

            return listsArray;
        }

        /// <summary>
        /// Unsampled measurements are sampled here. A 5 minutes time frame
        /// is usde to sample only one value. Finally a list of sampled
        /// Measurements is returned.
        /// </summary>
        /// <param name="startOfSampling">Instant contains the start of the
        /// sampling as DateTime.</param>
        /// <param name="unsampledList">List contains unsampled Measurements.
        /// </param>
        /// <returns>A list of sampled Measurements is returned.</returns>
        public List<Measurement> SampledMeasurementList(
            Instant startOfSampling,
            List<Measurement> unsampledList)
        {
            Measurement[] measurementsArray = null;
            DateTime currentTimeFrame = startOfSampling.Time.AddMinutes(5);
            List<Measurement> sampledList = new List<Measurement>();

            // Sorts unsampled List ascending.
            unsampledList.Sort((a, b) => a.CompareTo(b));

            // Copies list content into an array.
            measurementsArray = unsampledList.ToArray();

            // Samples in 5 minutes time frames.
            try
            {

                for (int i = 0; i < measurementsArray?.Length; i++)
                {

                    // Checks a sample for smaller or exact on border of time
                    // frame.
                    if (measurementsArray[i].MeasurementTime.Time.CompareTo(currentTimeFrame) == 0
                        ||
                        measurementsArray[i].MeasurementTime.Time.CompareTo(currentTimeFrame) == -1
                        &&
                        i < measurementsArray.Length - 1)
                    {

                        // Check for last sample in 5. min time frame.
                        if (measurementsArray[i + 1].MeasurementTime.Time.CompareTo(currentTimeFrame) == 1)
                        {

                            // Increase currentTimeFrame and manipulate time of
                            // sample. Adds value to sampledList.
                            measurementsArray[i].MeasurementTime.Time = currentTimeFrame;
                            sampledList.Add(measurementsArray[i]);
                            currentTimeFrame = currentTimeFrame.AddMinutes(5);
                        }
                    }

                    // This is the last sample inside list and adds this to
                    // sampledList.
                    else
                    {

                        // Increase currentTimeFrame and manipulate time of
                        // sample. Adds value to sampledList.
                        measurementsArray[i].MeasurementTime.Time = currentTimeFrame;
                        sampledList.Add(measurementsArray[i]);
                    }
                }
            }
            catch (Exception exception)
            {

                // Writes an exception output for debugging on screen.
                Console.Write($"{exception.Message}\nSource in Code: " +
                    $"{exception.Source}\n" +
                    $"Stack Trace: {exception.StackTrace}\n");
            }

            return sampledList;
        }
    }
}
