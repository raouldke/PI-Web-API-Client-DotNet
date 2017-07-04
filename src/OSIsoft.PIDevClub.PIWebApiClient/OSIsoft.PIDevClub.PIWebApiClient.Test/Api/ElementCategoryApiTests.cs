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
using OSIsoft.AF;
using OSIsoft.PIDevClub.PIWebApiClient.Api;
using OSIsoft.PIDevClub.PIWebApiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing ElementCategoryApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ElementCategoryApiTests : CommonApi
    {
        private IElementCategoryApi instance;
        private string webId;
        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.ElementCategory;
            base.CreateSampleDatabaseForTests();

            string path = Constants.AF_ELEMENT_CATEGORY_PATH;
            string selectedFields = null;
            webId = instance.GetByPath(path, selectedFields).WebId;
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            base.DeleteSampleDatabaseForTests();
        }

        /// <summary>
        /// Test an instance of ElementCategoryApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ElementCategoryApi
            Assert.IsInstanceOf(typeof(ElementCategoryApi), instance, "instance is a ElementCategoryApi");
        }

        
        /// <summary>
        /// Test CreateSecurityEntry
        /// </summary>
        [Test]
        public void CreateSecurityEntryTest()
        {
            PISecurityEntry securityEntry = new PISecurityEntry();
            securityEntry.SecurityIdentityName = Constants.AF_SECURITY_IDENTITY_NAME;
            securityEntry.AllowRights = new List<string>() { "ReadWrite", "Delete", "Execute", "Admin" };
            securityEntry.DenyRights = new List<string>() { "ReadWriteData", "Subscribe", "SubscribeOthers", "Annotate", "None" };
            bool? applyToChildren = null;
            instance.CreateSecurityEntry(webId, securityEntry, applyToChildren);
            var secEntry = instance.GetSecurityEntries(webId).Items.Where(m => m.Name == Constants.AF_SECURITY_IDENTITY_NAME).FirstOrDefault();
            Assert.IsNotNull(secEntry);
        }
        
        /// <summary>
        /// Test Delete
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            instance.Delete(webId);
            AFDatabase db = StandardPISystem.Databases[Constants.AF_DATABASE_NAME];
            db.Refresh();
            AFCategory category = AFObject.FindObject(Constants.AF_ELEMENT_CATEGORY_PATH) as AFCategory;
            Assert.IsNull(category);
            DeleteSampleDatabaseForTests();
            CreateSampleDatabaseForTests();
        }
        
        /// <summary>
        /// Test DeleteSecurityEntry
        /// </summary>
        [Test]
        public void DeleteSecurityEntryTest()
        {
            string name = Constants.AF_SECURITY_IDENTITY_NAME;
            PISecurityEntry securityEntry = null;
            try
            {
                securityEntry = instance.GetSecurityEntryByName(webId: webId, name: name);
            }
            catch (Exception)
            {
                if (securityEntry == null)
                {
                    CreateSecurityEntryTest();
                }
            }
            bool? applyToChildren = null;
            instance.DeleteSecurityEntry(webId: webId, name: name, applyToChildren: applyToChildren);
            var secEntry = instance.GetSecurityEntries(webId).Items.Where(m => m.Name == name).FirstOrDefault();
            Assert.IsNull(secEntry);
        }
        
        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            string selectedFields = null;
            var response = instance.Get(webId, selectedFields);
            Assert.IsInstanceOf<PIElementCategory>(response, "response is PICategory");
        }
        
        /// <summary>
        /// Test GetByPath
        /// </summary>
        [Test]
        public void GetByPathTest()
        {
            string path = Constants.AF_ELEMENT_CATEGORY_PATH;
            string selectedFields = null;
            var response = instance.GetByPath(path, selectedFields);
            Assert.IsInstanceOf<PIElementCategory>(response, "response is PICategory");
        }
        
        /// <summary>
        /// Test GetSecurity
        /// </summary>
        [Test]
        public void GetSecurityTest()
        {
            List<string> userIdentity = new List<string>() { @"marc\marc.adm", @"marc\marc.user" };
            bool? forceRefresh = null;
            string selectedFields = null;
            var response = instance.GetSecurity(webId, userIdentity, forceRefresh, selectedFields);
            Assert.IsInstanceOf<PIItemsSecurityRights>(response, "response is PIItemsSecurityRights");
        }
        
        /// <summary>
        /// Test GetSecurityEntries
        /// </summary>
        [Test]
        public void GetSecurityEntriesTest()
        {
            string nameFilter = null;
            string selectedFields = null;
            var response = instance.GetSecurityEntries(webId, nameFilter, selectedFields);
            Assert.IsInstanceOf<PIItemsSecurityEntry>(response, "response is PIItemsSecurityEntry");
            Assert.IsTrue(response.Items.Count > 0);
        }

        [Test]
        public void GetSecurityEntriesTest1()
        {
            string selectedFields = null;
            var response = instance.GetSecurityEntries(webId, "Administrators", selectedFields);
            Assert.IsInstanceOf<PIItemsSecurityEntry>(response, "response is PIItemsSecurityEntry");
            Assert.IsTrue(response.Items.Count > 0);
        }
        
        /// <summary>
        /// Test GetSecurityEntryByName
        /// </summary>
        [Test]
        public void GetSecurityEntryByNameTest()
        {
            string name = "Administrators";
            string selectedFields = null;
            var response = instance.GetSecurityEntryByName(webId: webId, name: name, selectedFields: selectedFields);
            Assert.IsInstanceOf<PISecurityEntry>(response, "response is PISecurityEntry");
            Assert.IsTrue(response.Name == name);
        }
        
        /// <summary>
        /// Test Update
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            string path = Constants.AF_ELEMENT_CATEGORY_PATH;
            PIElementCategory category = instance.GetByPath(path, null);
            category.Id = null;
            category.Description = "New element category description";
            category.Links = null;
            category.Path = null;
            category.WebId = null;
            instance.Update(webId, category);

            StandardPISystem.Refresh();
            AFCategory myCategory = AFObject.FindObject(path) as AFCategory;
            myCategory.Refresh();
            myCategory.Database.Refresh();
            if (myCategory != null)
            {
                Assert.IsTrue(myCategory.Description == category.Description);
            }
        }
        
        /// <summary>
        /// Test UpdateSecurityEntry
        /// </summary>
        [Test]
        public void UpdateSecurityEntryTest()
        {
            string name = Constants.AF_SECURITY_IDENTITY_NAME;
            PISecurityEntry securityEntry = null;
            try
            {
                securityEntry = instance.GetSecurityEntryByName(webId: webId, name: name);
            }
            catch (Exception)
            {
                if (securityEntry == null)
                {
                    CreateSecurityEntryTest();
                }
            }
            securityEntry = instance.GetSecurityEntryByName(webId: webId, name: name);
            securityEntry.AllowRights = new List<string>() { "ReadWrite", "Delete", "Execute", "Admin", "Subscribe", "ReadWriteData" };
            securityEntry.DenyRights = new List<string>() { "SubscribeOthers", "Annotate", "None" };
            securityEntry.Name = null;
            securityEntry.Links = null;
            securityEntry.SecurityIdentityName = null;
            bool? applyToChildren = null;
            instance.UpdateSecurityEntry(webId: webId, name: name, securityEntry: securityEntry, applyToChildren: applyToChildren);

            PISecurityEntry securityEntryUpdated = instance.GetSecurityEntryByName(webId: webId, name: name);
            Assert.IsTrue(securityEntry.AllowRights.Count == securityEntryUpdated.AllowRights.Count);
        }
        
    }

}
