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
using System.Collections.Generic;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing SystemApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class SystemApiTests
    {
        private ISystemApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            PIWebApiClient client = PIWebApiClientGenerator.GenerateInstance();
            instance = client.System;
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of SystemApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' SystemApi
            Assert.IsInstanceOf(typeof(SystemApi), instance, "instance is a SystemApi");

        }


        /// <summary>
        /// Test CacheInstances
        /// </summary>
        [Test]
        public void CacheInstancesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            var response = instance.CacheInstances();
            Assert.IsTrue(response.Items.Count > 0);
            Assert.IsInstanceOf<PIItemsCacheInstance>(response, "response is PIItemsCacheInstance");
        }

        /// <summary>
        /// Test Landing
        /// </summary>
        [Test]
        public void LandingTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            var response = instance.Landing();
            Assert.IsTrue(response.Links.Count > 0);
            Assert.IsInstanceOf<PISystemLanding>(response, "response is PILinks");
        }

        /// <summary>
        /// Test UserInfo
        /// </summary>
        [Test]
        public void UserInfoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            var response = instance.UserInfo();
            Assert.IsTrue(string.IsNullOrEmpty(response.Name)==false);
            Assert.IsInstanceOf<PIUserInfo>(response, "response is PIUserInfo");
        }

        /// <summary>
        /// Test Versions
        /// </summary>
        [Test]
        public void VersionsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            var response = instance.Versions();
            Assert.IsTrue(response.Count > 0);
            Assert.IsInstanceOf<Dictionary<string, PIVersion>>(response, "response is Dictionary<string, PIVersion>");
        }

    }

}
