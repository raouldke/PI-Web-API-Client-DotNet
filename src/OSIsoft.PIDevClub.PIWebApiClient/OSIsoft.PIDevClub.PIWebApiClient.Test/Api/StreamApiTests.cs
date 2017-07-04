// ************************************************************************
//
// * Copyright 2017 OSIsoft, LLC
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// * 
// *   <http://www.apache.org/licenses/LICENSE-2.0>
// * 
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// ************************************************************************

using NUnit.Framework;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Time;
using OSIsoft.PIDevClub.PIWebApiClient.Api;
using OSIsoft.PIDevClub.PIWebApiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing StreamApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class StreamApiTests : CommonApi
    {

        private IStreamApi instance;
        private string webId = null;
        private OSIsoft.AF.PI.PIPoint point = null;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.Stream;
            point = GetPIPoint("sinusoid");
            webId = client.Point.GetByPath(Constants.DATA_SERVER_PATH + @"\sinusoid").WebId;
        }



        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of StreamApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' StreamApi
            Assert.IsInstanceOf(typeof(StreamApi), instance, "instance is a StreamApi");
        }


        /// <summary>
        /// Test GetEnd
        /// </summary>
        [Test]
        public void GetEndTest()
        {
            string desiredUnits = null;
            string selectedFields = null;
            var response = instance.GetEnd(webId, desiredUnits, selectedFields);
            Assert.IsInstanceOf<PITimedValue>(response, "response is PITimedValue");

            AFValue value = point.EndOfStream();
            float afValue = value.ValueAsSingle();
            float piwaValue = Convert.ToSingle(response.Value);
            Assert.IsTrue(afValue == piwaValue);
        }

        /// <summary>
        /// Test GetInterpolated
        /// </summary>
        [Test]
        public void GetInterpolatedTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string startTime = Constants.TIME_START;
            string endTime = Constants.TIME_END;
            string timeZone = null;

            string interval = Constants.TIME_INTERVAL;
            string desiredUnits = null;
            string filterExpression = null;
            bool includeFilteredValues = true;
            string selectedFields = null;
            var response = instance.GetInterpolated(webId, startTime: startTime, endTime: endTime, timeZone: timeZone, interval: interval, desiredUnits: desiredUnits, filterExpression: filterExpression, includeFilteredValues: includeFilteredValues, selectedFields: selectedFields);
            Assert.IsInstanceOf<PITimedValues>(response, "response is PITimedValues");

            AFTimeRange timeRange = new AFTimeRange(new AFTime(Constants.TIME_START), new AFTime(Constants.TIME_END));
            AFTimeSpan timeSpan = AFTimeSpan.Parse(interval);
            AFValues values = point.InterpolatedValues(timeRange, timeSpan, filterExpression, includeFilteredValues);

            Assert.IsTrue(response.Items.Count > 10);
            Assert.IsTrue(response.Items.Count == values.Count);
        }

        /// <summary>
        /// Test GetInterpolatedAtTimes
        /// </summary>
        [Test]
        public void GetInterpolatedAtTimesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            List<string> time = new List<string>() { "*-5h", "*-9h", "*-11h" };
            string timeZone = null;
            string desiredUnits = null;
            string filterExpression = null;
            bool includeFilteredValues = false;
            string sortOrder = "Descending";
            string selectedFields = null;
            var response = instance.GetInterpolatedAtTimes(webId, time: time, timeZone: timeZone, desiredUnits: desiredUnits, filterExpression: filterExpression, includeFilteredValues: includeFilteredValues, sortOrder: sortOrder, selectedFields: selectedFields);
            Assert.IsInstanceOf<PITimedValues>(response, "response is PITimedValues");


            IList<AFTime> times = time.Select(t => new AFTime(t)).ToList();
            AFValues values = point.InterpolatedValuesAtTimes(times, filterExpression, includeFilteredValues);
            float afValue = values.First().ValueAsSingle();
            float piwaValue = Convert.ToSingle(response.Items.First().Value);
            Assert.IsTrue(afValue == piwaValue);
        }

        /// <summary>
        /// Test GetPlot
        /// </summary>
        [Test]
        public void GetPlotTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string startTime = Constants.TIME_START;
            string endTime = Constants.TIME_END;
            string timeZone = null;
            int? intervals = Constants.TIME_INTERVALS;
            string desiredUnits = null;
            string selectedFields = null;
            var response = instance.GetPlot(webId, startTime: startTime, endTime: endTime, timeZone: timeZone, intervals: intervals, desiredUnits: desiredUnits, selectedFields: selectedFields);
            Assert.IsInstanceOf<PITimedValues>(response, "response is PITimedValues");


            AFTimeRange timeRange = new AFTimeRange(new AFTime(Constants.TIME_START), new AFTime(Constants.TIME_END));
            AFValues values = point.PlotValues(timeRange, Constants.TIME_INTERVALS);

            Assert.IsTrue(response.Items.Count > 10);
            Assert.IsTrue(response.Items.Count == values.Count);

        }

        /// <summary>
        /// Test GetRecorded
        /// </summary>
        [Test]
        public void GetRecordedTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string startTime = Constants.TIME_START;
            string endTime = Constants.TIME_END;
            string timeZone = null;
            string boundaryType = "Inside";
            string desiredUnits = null;
            string filterExpression = null;
            bool? includeFilteredValues = null;
            int? maxCount = null;
            string selectedFields = null;
            var response = instance.GetRecorded(webId, startTime: startTime, endTime: endTime, timeZone: timeZone, boundaryType: boundaryType, desiredUnits: desiredUnits, filterExpression: filterExpression, includeFilteredValues: includeFilteredValues, maxCount: maxCount, selectedFields: selectedFields);
            Assert.IsInstanceOf<PITimedValues>(response, "response is PITimedValues");


            AFTimeRange timeRange = new AFTimeRange(new AFTime(Constants.TIME_START), new AFTime(Constants.TIME_END));
            AFValues values = point.RecordedValues(timeRange, AF.Data.AFBoundaryType.Inside, string.Empty, true);

            Assert.IsTrue(response.Items.Count > 10);
            Assert.IsTrue(response.Items.Count == values.Count);
        }

        /// <summary>
        /// Test GetRecordedAtTime
        /// </summary>
        [Test]
        public void GetRecordedAtTimeTest()
        {


            string time = "*-2d";
            string timeZone = null;
            string retrievalMode = "After";
            string desiredUnits = null;
            string selectedFields = null;
            var response = instance.GetRecordedAtTime(webId, time, timeZone, retrievalMode, desiredUnits, selectedFields);
            Assert.IsInstanceOf<PITimedValue>(response, "response is PITimedValue");

            IList<AFTime> times = new List<AFTime>() { new AFTime(time) };
            AFValues values = point.RecordedValuesAtTimes(times, AF.Data.AFRetrievalMode.After);
            float afValue = values.First().ValueAsSingle();
            float piwaValue = Convert.ToSingle(response.Value);
            Assert.IsTrue(afValue == piwaValue);
        }

        /// <summary>
        /// Test GetSummary
        /// </summary>
        [Test]
        public void GetSummaryTest()
        {
            //// TODO uncomment below to test the method and replace null with proper value
            string startTime = Constants.TIME_START;
            string endTime = Constants.TIME_END;
            string timeZone = null;
            List<string> summaryType = new List<string>() { "Maximum", "Minimum" };
            string calculationBasis = "EventWeighted";
            string timeType = "Auto";
            string summaryDuration = Constants.TIME_INTERVAL;
            string sampleType = "Interval";
            string sampleInterval = null;
            string filterExpression = null;
            string selectedFields = null;
            var response = instance.GetSummary(webId, startTime: startTime, endTime: endTime, timeZone: timeZone, summaryType: summaryType, calculationBasis: calculationBasis, timeType: timeType, summaryDuration: summaryDuration, sampleType: sampleType, sampleInterval: sampleInterval, filterExpression: filterExpression, selectedFields: selectedFields);
            Assert.IsInstanceOf<PIItemsSummaryValue>(response, "response is PIItemsSummaryValue");
            Assert.IsTrue(response.Items.Count > 0);
        }

        /// <summary>
        /// Test GetValue
        /// </summary>
        [Test]
        public void GetValueTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string time = "*-2d";
            string timeZone = null;
            string desiredUnits = null;
            string selectedFields = null;
            var response = instance.GetValue(webId: webId, time: time, timeZone: timeZone, desiredUnits: desiredUnits, selectedFields: selectedFields);
            Assert.IsInstanceOf<PITimedValue>(response, "response is PITimedValue");

            AFValue value = point.RecordedValue(new AFTime(time));
            float afValue = value.ValueAsSingle();
            float piwaValue = Convert.ToSingle(response.Value);
            Assert.IsTrue(afValue == piwaValue);
        }

        /// <summary>
        /// Test UpdateValue
        /// </summary>
        [Test]
        public void UpdateValueTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            var currentTime = "*-1d";
            PITimedValue value = new PITimedValue()
            {
                Timestamp = currentTime,
                Value = 30
            };
            string updateOption = "Replace";
            string bufferOption = "BufferIfPossible";
            instance.UpdateValue(webId: webId, value: value,  updateOption: updateOption, bufferOption: bufferOption);
            var afValue = point.RecordedValue(new AFTime(currentTime));
            Assert.IsTrue(afValue.ValueAsSingle() == Convert.ToSingle(value.Value));

        }

        /// <summary>
        /// Test UpdateValues
        /// </summary>
        [Test, Order(1)]
        public void UpdateValuesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value

            var currentTime1 = "*-1d";
            var currentTime2 = "*-2d";
            PITimedValue value1 = new PITimedValue()
            {
                Timestamp = currentTime1,
                Value = 40
            };
            PITimedValue value2 = new PITimedValue()
            {
                Timestamp = currentTime2,
                Value = 50
            };
            string updateOption = "Replace";
            string bufferOption = "BufferIfPossible";



            List<PITimedValue> values = new List<PITimedValue>();
            values.Add(value1);
            values.Add(value2);

            instance.UpdateValues(webId: webId, values: values, updateOption: updateOption, bufferOption: bufferOption);

            //AFCache.Clear();

            //var afValue1 = point.RecordedValue(new AFTime(currentTime1));
            //int v1a = afValue1.ValueAsInt32();
            //int v1b = Convert.ToInt32(value1.Value);
            //Assert.IsTrue(v1a == v1b);


            //var afValue2 = point.RecordedValue(new AFTime(currentTime2));
            //int v2a = afValue2.ValueAsInt32();
            //int v2b = Convert.ToInt32(value2.Value);
            //Assert.IsTrue(v2a == v2b);


        }

    }

}
