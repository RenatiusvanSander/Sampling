using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bewerbungsaufgabe.Models;
using System.Collections.Generic;

namespace UnitTestProgram
{

    /// <summary>
    /// This class tests the unit sampling.
    /// </summary>
    [TestClass]
    public class UnitTestSampling
    {

        /// <summary>
        /// Tests Sampling.CreateSamples(). Here is created an unsampled and
        /// not ordered list of Measurements. 7 objects are to check inside
        /// the list.
        /// </summary>
        [TestMethod]
        public void TestMethodCreateSamples()
        {
            List<Measurement> expectedList = new List<Measurement>();
            Measurement[] expectedMeasurement = new Measurement[7];
            Sampling actualSampling = new Sampling();
            List<Measurement> actualUnsampledList = actualSampling.CreateSamples();

            // Creates measurementsArray and fills values.
            expectedMeasurement[0] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:04:45") },
                MeasurementValue = 35.79,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[1] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:01:18") },
                MeasurementValue = 98.78,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[2] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:09:07") },
                MeasurementValue = 35.01,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[3] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:03:34") },
                MeasurementValue = 96.49,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[4] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:02:01") },
                MeasurementValue = 35.82,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[5] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 97.17,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[6] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:01") },
                MeasurementValue = 95.08,
                Type = MeasurementType.SPO2
            };

            // Adds all measurementsArray elements to measurmentsList.
            foreach (Measurement measurement in expectedMeasurement)
            {
                expectedList.Add(measurement);
            }

            // Checks content of CreateSamples() is the same.
            // Checks element 7.
            Assert.AreEqual(7, actualUnsampledList.Count);
            Assert.AreEqual(expectedMeasurement[6].MeasurementTime.Time,
                actualUnsampledList.ToArray()[6].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[6].MeasurementValue,
                actualUnsampledList.ToArray()[6].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[6].Type,
                actualUnsampledList.ToArray()[6].Type);

            // Checks element 6.
            Assert.AreEqual(expectedMeasurement[5].MeasurementTime.Time,
                actualUnsampledList.ToArray()[5].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[5].MeasurementValue,
                actualUnsampledList.ToArray()[5].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[5].Type,
                actualUnsampledList.ToArray()[5].Type);

            // Checks element 5.
            Assert.AreEqual(expectedMeasurement[4].MeasurementTime.Time,
                actualUnsampledList.ToArray()[4].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[4].MeasurementValue,
                actualUnsampledList.ToArray()[4].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[4].Type,
                actualUnsampledList.ToArray()[4].Type);

            // Checks element 4.
            Assert.AreEqual(expectedMeasurement[3].MeasurementTime.Time,
                actualUnsampledList.ToArray()[3].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[3].MeasurementValue,
                actualUnsampledList.ToArray()[3].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[3].Type,
                actualUnsampledList.ToArray()[3].Type);

            // Checks element 3.
            Assert.AreEqual(expectedMeasurement[2].MeasurementTime.Time,
                actualUnsampledList.ToArray()[2].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[2].MeasurementValue,
                actualUnsampledList.ToArray()[2].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[2].Type,
                actualUnsampledList.ToArray()[2].Type);

            // Checks element 2.
            Assert.AreEqual(expectedMeasurement[1].MeasurementTime.Time,
                actualUnsampledList.ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[1].MeasurementValue,
                actualUnsampledList.ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[1].Type,
                actualUnsampledList.ToArray()[1].Type);

            // Checks element 1.
            Assert.AreEqual(expectedMeasurement[0].MeasurementTime.Time,
                actualUnsampledList.ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[0].MeasurementValue,
                actualUnsampledList.ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[0].Type,
                actualUnsampledList.ToArray()[0].Type);
        }

        /// <summary>
        /// Tests Sampling.CreatesLists(). Unsampled Measurements List is
        /// separated into two lists. Lists are temperature with 3 entries
        /// and spo2 with 4 entries, which is tested first. Then the all
        /// objects inside the lists are checked.
        /// </summary>
        [TestMethod]
        public void TestMethodCreatesLists()
        {
            Measurement[] expectedMeasurement = new Measurement[7];
            Sampling actualSampling = new Sampling();
            List<Measurement> actualUnsampledList = actualSampling.CreateSamples();
            List<Measurement>[] actualListsArray = actualSampling.CreateLists(actualUnsampledList);

            // Creates measurementsArray and fills values.
            expectedMeasurement[0] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:04:45") },
                MeasurementValue = 35.79,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[1] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:01:18") },
                MeasurementValue = 98.78,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[2] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:09:07") },
                MeasurementValue = 35.01,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[3] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:03:34") },
                MeasurementValue = 96.49,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[4] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:02:01") },
                MeasurementValue = 35.82,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[5] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 97.17,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[6] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:01") },
                MeasurementValue = 95.08,
                Type = MeasurementType.SPO2
            };

            // Checks for content is 3 and list of spo2 has 4 centries.
            Assert.AreEqual(3, actualListsArray[0].Count);
            Assert.AreEqual(4, actualListsArray[1].Count);

            // Checks list of temperatures for 3 right entries.
            Assert.AreEqual(expectedMeasurement[0].MeasurementTime.Time, actualListsArray[0].ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[0].MeasurementValue, actualListsArray[0].ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[0].Type, actualListsArray[0].ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[2].MeasurementTime.Time, actualListsArray[0].ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[2].MeasurementValue, actualListsArray[0].ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[2].Type, actualListsArray[0].ToArray()[1].Type);
            Assert.AreEqual(expectedMeasurement[4].MeasurementTime.Time, actualListsArray[0].ToArray()[2].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[4].MeasurementValue, actualListsArray[0].ToArray()[2].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[4].Type, actualListsArray[0].ToArray()[2].Type);

            // Checks list of spo2 for 4 right entries.
            Assert.AreEqual(expectedMeasurement[1].MeasurementTime.Time, actualListsArray[1].ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[1].MeasurementValue, actualListsArray[1].ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[1].Type, actualListsArray[1].ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[3].MeasurementTime.Time, actualListsArray[1].ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[3].MeasurementValue, actualListsArray[1].ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[3].Type, actualListsArray[1].ToArray()[1].Type);
            Assert.AreEqual(expectedMeasurement[5].MeasurementTime.Time, actualListsArray[1].ToArray()[2].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[5].MeasurementValue, actualListsArray[1].ToArray()[2].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[5].Type, actualListsArray[1].ToArray()[2].Type);
            Assert.AreEqual(expectedMeasurement[6].MeasurementTime.Time, actualListsArray[1].ToArray()[3].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[6].MeasurementValue, actualListsArray[1].ToArray()[3].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[6].Type, actualListsArray[1].ToArray()[3].Type);
        }

        /// <summary>
        /// Here is tested the sampling of Sampling.SampledMeasurementList().
        /// Boths lists, temperature and spo2, are sampled. The results are
        /// two new lists, which are checked every list for two entries and
        /// the objects.
        /// </summary>
        [TestMethod]
        public void TestMethodSampledMeasurementList()
        {
            Measurement[] expectedMeasurement = new Measurement[7];
            Sampling actualSampling = new Sampling();
            Instant actualStartOfSampling = new Instant()
            {
                Time = DateTime.Parse("2017-01-03T10:00:00"),
            };
            List<Measurement> actualUnsampledList =
                actualSampling.CreateSamples();
            List<Measurement>[] actualListsArray =
                actualSampling.CreateLists(actualUnsampledList);
            List<Measurement> actualTemperatureSampledList =
                actualSampling.SampledMeasurementList(actualStartOfSampling, actualListsArray[0]);
            List<Measurement> actualSPO2SampledList =
                actualSampling.SampledMeasurementList(actualStartOfSampling, actualListsArray[1]);

            // Creates measurementsArray and fills values.
            expectedMeasurement[0] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 35.79,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[1] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:10:00") },
                MeasurementValue = 35.01,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[2] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 97.17,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[3] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:10:00") },
                MeasurementValue = 95.08,
                Type = MeasurementType.SPO2
            };

            // Checks for right lengths. Shall be 2.
            Assert.AreEqual(2, actualTemperatureSampledList.Count);
            Assert.AreEqual(2, actualTemperatureSampledList.Count);

            // Checks actualTemperatureSampledList is sorted and is equal.
            Assert.AreEqual(expectedMeasurement[0].MeasurementTime.Time,
                actualTemperatureSampledList.ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[0].MeasurementValue,
                actualTemperatureSampledList.ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[0].Type,
                actualTemperatureSampledList.ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[1].MeasurementTime.Time,
                actualTemperatureSampledList.ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[1].MeasurementValue,
                actualTemperatureSampledList.ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[1].Type,
                actualTemperatureSampledList.ToArray()[1].Type);

            // Checks actualSpo2SampledList is sorted and is equal.
            Assert.AreEqual(expectedMeasurement[2].MeasurementTime.Time,
               actualSPO2SampledList.ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[2].MeasurementValue,
                actualSPO2SampledList.ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[2].Type,
                actualSPO2SampledList.ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[3].MeasurementTime.Time,
               actualSPO2SampledList.ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[3].MeasurementValue,
                actualSPO2SampledList.ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[3].Type,
                actualSPO2SampledList.ToArray()[1].Type);
        }

        /// <summary>
        /// Here is Sampling.Sample() tested. Unsampled Measurements are inside
        /// a list given to Sample method. Returned is a Map, which is to test
        /// for 2 Keys and each list stores 2 Measurement objects. Content is
        /// checked.
        /// </summary>
        [TestMethod]
        public void TestMethodSample()
        {
            Measurement[] expectedMeasurement = new Measurement[7];
            Sampling actualSampling = new Sampling();
            Instant actualStartOfSampling = new Instant()
            {
                Time = DateTime.Parse("2017-01-03T10:00:00"),
            };
            List<Measurement> actualUnsampledList =
                actualSampling.CreateSamples();
            Map<MeasurementType, List<Measurement>> actualSampledMap =
                actualSampling.Sample(actualStartOfSampling, actualUnsampledList);

            // Creates measurementsArray and fills values.
            expectedMeasurement[0] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 35.79,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[1] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:10:00") },
                MeasurementValue = 35.01,
                Type = MeasurementType.TEMP
            };
            expectedMeasurement[2] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:05:00") },
                MeasurementValue = 97.17,
                Type = MeasurementType.SPO2
            };
            expectedMeasurement[3] = new Measurement
            {
                MeasurementTime = new Instant() { Time = DateTime.Parse("2017-01-03T10:10:00") },
                MeasurementValue = 95.08,
                Type = MeasurementType.SPO2
            };

            // Checks Map-Object has two entries.
            Assert.AreEqual(2, actualSampledMap.Count);

            // Checks temperatures are sorted and are equal to expectedObjects.
            Assert.AreEqual(expectedMeasurement[0].MeasurementTime.Time,
                actualSampledMap[0].ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[0].MeasurementValue,
                actualSampledMap[0].ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[0].Type,
            actualSampledMap[0].ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[1].MeasurementTime.Time,
                actualSampledMap[0].ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[1].MeasurementValue,
                actualSampledMap[0].ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[1].Type,
            actualSampledMap[0].ToArray()[1].Type);

            // Checks spo2s are sorted and are equal to expectedObjects.
            Assert.AreEqual(expectedMeasurement[2].MeasurementTime.Time,
                actualSampledMap[MeasurementType.SPO2].ToArray()[0].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[2].MeasurementValue,
                actualSampledMap[MeasurementType.SPO2].ToArray()[0].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[2].Type,
            actualSampledMap[MeasurementType.SPO2].ToArray()[0].Type);
            Assert.AreEqual(expectedMeasurement[3].MeasurementTime.Time,
                actualSampledMap[MeasurementType.SPO2].ToArray()[1].MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement[3].MeasurementValue,
                actualSampledMap[MeasurementType.SPO2].ToArray()[1].MeasurementValue);
            Assert.AreEqual(expectedMeasurement[3].Type,
            actualSampledMap[MeasurementType.SPO2].ToArray()[1].Type);
        }
    }
}
