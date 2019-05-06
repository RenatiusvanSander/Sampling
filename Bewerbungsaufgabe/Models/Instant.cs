using System;

namespace Bewerbungsaufgabe.Models
{

    /// <summary>
    /// Instant initializes a time series as DateTime.
    /// </summary>
    public class Instant
    {
        public Instant() { }

        // Sets or gets the time series.
        public DateTime Time { set; get; }

        /// <summary>
        /// Shows content of the Instant object.
        /// This returns a string of object
        /// content
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return Time.ToString();
        }
    }
}