using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Bewerbungsaufgabe.Models
{

    /// <summary>
    /// Contains one sample as measurment, which is initialized by a 
    /// measurement class.
    /// </summary>
    public class Measurement
    {

        /// <summary>
        /// Ctor sets number format
        /// </summary>
        public Measurement()
        {
            InitNumberFormatInfoForDouble();
        }
        
        private NumberFormatInfo numberFormatInfo;
        private Instant measurementTime;
        private Double measurementValue;
        private MeasurementType type;

        // Sets or gets measurementTime, which holds the time of a sample.
        public Instant MeasurementTime {
            get
            {
                return measurementTime;
            }
            set
            {
                if (measurementTime != value)
                {
                    measurementTime = value;
                }
            }
        }

        // Sets or gets measurementValue, which holds the value of a sample.
        public Double MeasurementValue
        {
            get
            {
                return measurementValue;
            }
            set
            {
                if(measurementValue != value)
                {
                    measurementValue = value;
                }
            }
        }

        // Sets or gets the type of a measurement,
        // which can be TEMP or SPO2.
        public MeasurementType Type
        {
            get
            {
                return type;
            }
            set
            {
                if(type != value)
                {
                    type = value;
                }
            }
        }

        /// <summary>
        /// Sets number format for double. It uses as separator ".".
        /// </summary>
        private void InitNumberFormatInfoForDouble()
        {
            numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
        }

        /// <summary>
        /// This method compares two Measurements objects
        /// </summary>
        /// <param name="measurement">Measurement</param>
        /// <returns>Returns an int which is 1, 0 or -1</returns>
        public int CompareTo(Measurement measurement)
        {
            int compareResult = MeasurementTime.Time.CompareTo(measurement.MeasurementTime.Time);
            return compareResult;
        }

        /// <summary>
        /// Shows content of the measurement as a string.
        /// This returns the content of object as string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Builds the string.
            sb.Append('{');
            sb.Append(measurementTime.ToString());
            sb.Append(", ");
            sb.Append(type);
            sb.Append(", ");
            sb.Append(measurementValue.ToString(numberFormatInfo));
            sb.Append('}');

            return sb.ToString();
        }
    }
}
