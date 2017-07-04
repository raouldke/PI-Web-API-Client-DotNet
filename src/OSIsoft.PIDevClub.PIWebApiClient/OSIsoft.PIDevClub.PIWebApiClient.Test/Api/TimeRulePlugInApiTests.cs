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
using OSIsoft.PIDevClub.PIWebApiClient.Api;
using OSIsoft.PIDevClub.PIWebApiClient.Model;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing TimeRulePlugInApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class TimeRulePlugInApiTests : CommonApi
    {
        private ITimeRulePlugInApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.TimeRulePlugIn;
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of TimeRulePlugInApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' TimeRulePlugInApi
            Assert.IsInstanceOf(typeof(TimeRulePlugInApi), instance, "instance is a TimeRulePlugInApi");
        }


        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            string path = Constants.AF_SERVER_PATH + @"\PlugInsAnalysisRule[Imbalance]";
            string selectedFields = null;
            var response2 = instance.GetByPath(path, selectedFields);
            string webId = response2.WebId;
            var response = instance.Get(webId, selectedFields);
            Assert.IsInstanceOf<PITimeRulePlugIn>(response, "response is PIPlugIn");
            Assert.IsTrue(response.Name == "Imbalance");
        }

        /// <summary>
        /// Test GetByPath
        /// </summary>
        [Test]
        public void GetByPathTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string path = Constants.AF_SERVER_PATH + @"\PlugInsAnalysisRule[Imbalance]";
            string selectedFields = null;
            var response = instance.GetByPath(path, selectedFields);
            Assert.IsInstanceOf<PITimeRulePlugIn>(response, "response is PIPlugIn");
            Assert.IsTrue(response.Name == "Imbalance");
        }

    }

}
