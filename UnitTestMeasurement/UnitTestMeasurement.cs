using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bewerbungsaufgabe.Models;

namespace UnitTestMeasurement
{

    /// <summary>
    /// This class tests the Measurement unit.
    /// </summary>
    [TestClass]
    public class UnitTestMeasurement
    {

        /// <summary>
        /// Tests the unit Measurement as class. It checks if the values are
        /// right.
        /// </summary>
        [TestMethod]
        public void TestMethodValues()
        {
            Measurement actutalMeasurement, expectedMeasurement;
            DateTime timeOfSample = DateTime.Parse("2017-01-03T10:04:45");
            Double valueOfSample = 35.79;
            MeasurementType typeOfSample = MeasurementType.TEMP;

            // Sets values.
            actutalMeasurement = new Measurement()
            {
                MeasurementTime = new Instant() { Time = timeOfSample },
                MeasurementValue = valueOfSample,
                Type = typeOfSample
            };
            expectedMeasurement = new Measurement()
            {
                MeasurementTime = new Instant() { Time = timeOfSample },
                MeasurementValue = valueOfSample,
                Type = typeOfSample
            };

            // Checks if values are same.
            Assert.AreEqual(expectedMeasurement.MeasurementTime.Time, actutalMeasurement.MeasurementTime.Time);
            Assert.AreEqual(expectedMeasurement.MeasurementValue, actutalMeasurement.MeasurementValue);
            Assert.AreEqual(expectedMeasurement.Type, actutalMeasurement.Type);
        }

        /// <summary>
        /// Tests ToString() method of Measuement class.
        /// </summary>
        [TestMethod]
        public void TestMethodToString()
        {
            Measurement actutalMeasurement, expectedMeasurement;
            DateTime timeOfSample = DateTime.Parse("2017-01-03T10:04:45");
            Double valueOfSample = 35.79;
            MeasurementType typeOfSample = MeasurementType.TEMP;

            // Sets values.
            actutalMeasurement = new Measurement()
            {
                MeasurementTime = new Instant() { Time = timeOfSample },
                MeasurementValue = valueOfSample,
                Type = typeOfSample
            };
            expectedMeasurement = new Measurement()
            {
                MeasurementTime = new Instant() { Time = timeOfSample },
                MeasurementValue = valueOfSample,
                Type = typeOfSample
            };

            // Checks ToString() method returns same string.
            Assert.AreEqual(expectedMeasurement.ToString(), actutalMeasurement.ToString());
        }
    }
}
