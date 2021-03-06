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
using System.Linq;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing PointApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class PointApiTests : CommonApi
    {
        private IPointApi instance;
        private string webId = null;
        private OSIsoft.AF.PI.PIPoint point = null;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.Point;
            base.CreatePIPoint(Constants.PIPOINT_CREATE_NAME);
            UpdatePIPointData();


        }

        public void UpdatePIPointData()
        {
            webId = client.Point.GetByPath(Constants.DATA_SERVER_PATH + @"\" + Constants.PIPOINT_CREATE_NAME).WebId;
            point = base.GetPIPoint(Constants.PIPOINT_CREATE_NAME);
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            base.DeletePIPoint(Constants.PIPOINT_CREATE_NAME);
        }

        /// <summary>
        /// Test an instance of PointApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' PointApi
            Assert.IsInstanceOf(typeof(PointApi), instance, "instance is a PointApi");
        }


        /// <summary>
        /// Test Delete
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            instance.Delete(webId);
            var oldPoint = base.GetPIPoint(Constants.PIPOINT_CREATE_NAME);
            Assert.IsNull(oldPoint);
            base.CreatePIPoint(Constants.PIPOINT_CREATE_NAME);
            UpdatePIPointData();

        }

        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string selectedFields = "Name;Future";
            var response = instance.Get(webId, selectedFields);
            Assert.IsInstanceOf<PIPoint>(response, "response is PIPoint");
            Assert.IsTrue(response.Name == Constants.PIPOINT_CREATE_NAME);
        }

        /// <summary>
        /// Test GetAttributeByName
        /// </summary>
        [Test]
        public void GetAttributeByNameTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string name = "descriptor";
            string selectedFields = null;
            var response = instance.GetAttributeByName(webId: webId, name: name, selectedFields: selectedFields);
            Assert.IsTrue(response.Value.ToString() == (point.GetAttributes().Where(m => m.Key == response.Name).First().Value.ToString()));
            Assert.IsInstanceOf<PIPointAttribute>(response, "response is PIPointAttribute");
        }

        /// <summary>
        /// Test GetAttributes
        /// </summary>
        [Test]
        public void GetAttributesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string nameFilter = null;
            List<string> name = null;
            string selectedFields = null;
            var response = instance.GetAttributes(webId, name, nameFilter, selectedFields);
            Assert.IsInstanceOf<PIItemsPointAttribute>(response, "response is PIItemsPointAttribute");
            var point = base.GetPIPoint(Constants.PIPOINT_CREATE_NAME);
            Assert.IsTrue(response.Items.Count == point.GetAttributes().Count);
        }

        /// <summary>
        /// Test GetByPath
        /// </summary>
        [Test]
        public void GetByPathTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string path = Constants.DATA_SERVER_PATH + @"\" + Constants.PIPOINT_CREATE_NAME;
            string selectedFields = null;
            var response = instance.GetByPath(path, selectedFields);
            Assert.IsTrue(response.Name == Constants.PIPOINT_CREATE_NAME);
            Assert.IsInstanceOf<PIPoint>(response, "response is PIPoint");
        }

        /// <summary>
        /// Test GetMultiple
        /// </summary>
        [Test]
        public void GetMultipleTest()
        {
            bool? asParallel = null;
            string includeMode = null;
            string selectedFields = null;
            PIPoint piPoint1 = instance.GetByPath(Constants.DATA_SERVER_PATH + @"\" + Constants.PIPOINT_CREATE_NAME);
            PIPoint piPoint2 = instance.GetByPath(Constants.DATA_SERVER_PATH + @"\sinusoidu");
            List<string> webId = new List<string>();

            webId.Add(piPoint1.WebId);
            webId.Add(piPoint2.WebId);
            var response = instance.GetMultiple(asParallel, includeMode, null, selectedFields, webId);
            Assert.IsInstanceOf<PIItemsItemPoint>(response, "response is PIItemsItemPoint");
            Assert.IsTrue(response.Items.Count == 2);
            Assert.IsTrue(response.Items[0].Object.WebId == piPoint1.WebId);

            List<string> path = new List<string>();
            path.Add(Constants.DATA_SERVER_PATH + @"\" + Constants.PIPOINT_CREATE_NAME);
            path.Add(Constants.DATA_SERVER_PATH + @"\sinusoid");
            var response2 = instance.GetMultiple(asParallel, includeMode, path, selectedFields, null);
            Assert.IsInstanceOf<PIItemsItemPoint>(response2, "response is PIItemsItemPoint");
            Assert.IsTrue(response2.Items.Count == 2);
            Assert.IsTrue(response.Items[0].Object.WebId == piPoint1.WebId);



        }

        /// <summary>
        /// Test Update
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            PIPoint modPoint = instance.GetByPath(Constants.DATA_SERVER_PATH + @"\" + Constants.PIPOINT_CREATE_NAME);
            modPoint.Descriptor = "Updated descriptor yay!!!";
            modPoint.WebId = null;
            modPoint.Id = null;
            modPoint.Path = null;
            modPoint.PointClass = null;
            modPoint.PointType = null;
            modPoint.DigitalSetName = null;
            modPoint.Links = null;
            modPoint.Future = null;
            instance.Update(webId, modPoint);
            UpdatePIPointData();
            point.LoadAttributes();
            Assert.IsTrue(point.GetAttribute("descriptor").ToString() == modPoint.Descriptor);

        }

        /// <summary>
        /// Test UpdateAttributeValue
        /// </summary>
        [Test]
        public void UpdateAttributeValueTest()
        {
            //string name = "location2";
            //Object value = 7;
            //instance.UpdateAttributeValue(webId, name, value);
            //UpdatePIPointData();
            //point.LoadAttributes();
            //Assert.IsTrue(point.GetAttribute("location2").ToString() == value.ToString());

        }

    }

}
