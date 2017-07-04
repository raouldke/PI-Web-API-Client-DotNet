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

using OSIsoft.AF;
using OSIsoft.AF.Analysis;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.EventFrame;
using OSIsoft.AF.Time;
using OSIsoft.AF.UnitsOfMeasure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    public class CommonApi
    {
        protected OSIsoft.AF.PI.PIServer _piServer;
        protected OSIsoft.AF.PISystem _piSystem;
        protected PIWebApiClient client;

        public OSIsoft.AF.PI.PIServer StandardPIServer
        {
            get
            {
                if (_piServer == null)
                {
                    _piServer = new OSIsoft.AF.PI.PIServers()[Constants.DATA_SERVER_NAME];
                }
                return _piServer;
            }
        }

        public OSIsoft.AF.PISystem StandardPISystem
        {
            get
            {
                if (_piSystem == null)
                {
                    _piSystem = new OSIsoft.AF.PISystems()[Constants.AF_SERVER_NAME];
                }
                return _piSystem;
            }
        }
        public void CommonInit()
        {
            client = PIWebApiClientGenerator.GenerateInstance();


        }


        public void CreatePIPoint(string name)
        {
            var point = GetPIPoint(name);
            if (point == null)
            {
                IDictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("descriptor", "Best tag ever!");
                StandardPIServer.CreatePIPoint(name, dic);
            }
        }

        public OSIsoft.AF.PI.PIPoint GetPIPoint(string name)
        {
            OSIsoft.AF.PI.PIPoint piPoint = null;
            var pointFound = OSIsoft.AF.PI.PIPoint.TryFindPIPoint(StandardPIServer, name, out piPoint);
            return piPoint;
        }

        public void DeletePIPoint(string name)
        {
            var point = GetPIPoint(name);
            if (point != null)
            {
                StandardPIServer.DeletePIPoint(Constants.PIPOINT_CREATE_NAME);
            }
        }

        public void DeletePIStateSet(string name)
        {
            var enumSet = StandardPIServer.StateSets[name];
            if (enumSet != null)
            {
                StandardPIServer.StateSets.Remove(enumSet);
                Debug.WriteLine("Deleting enum Set");
            }
        }

        private AFSecurityMapping myMapping;
        private AFSecurityIdentity myIdentity;

        private void CreateSecurityIdentities()
        {
            myIdentity = StandardPISystem.SecurityIdentities[Constants.AF_SECURITY_IDENTITY_NAME];
            if (myIdentity == null)
            {
                myIdentity = StandardPISystem.SecurityIdentities.Add(Constants.AF_SECURITY_IDENTITY_NAME);
                myIdentity.Description = "Test User Identity";
                myIdentity.CheckIn();
            }
        }

        private void CreateSecurityMappings()
        {
            myMapping = StandardPISystem.SecurityMappings[Constants.AF_SECURITY_MAPPING_NAME];
            if (myMapping == null)
            {
                myMapping = _piSystem.SecurityMappings.Add(Constants.AF_SECURITY_MAPPING_NAME, null, myIdentity);
                myMapping.Description = "Current User Mapping";
                myMapping.CheckIn();
            }
        }

        private void CreateUOMClasses()
        {
            UOMClass uomClass = StandardPISystem.UOMDatabase.UOMClasses[Constants.AF_UOM_CLASS_NAME];
            if (uomClass == null)
            {
                uomClass = StandardPISystem.UOMDatabase.UOMClasses.Add(Constants.AF_UOM_CLASS_NAME, Constants.AF_UOM_CLASS_UNIT, Constants.AF_UOM_CLASS_ABBR);
                uomClass.Description = "Old description";
            }


            UOM refUom = StandardPISystem.UOMDatabase.UOMs[Constants.AF_UOM_CLASS_UNIT];
            UOM uom = StandardPISystem.UOMDatabase.UOMs[Constants.AF_UOM_NAME];
            if (uom == null)
            {
                uom = StandardPISystem.UOMDatabase.UOMs.Add(Constants.AF_UOM_NAME, Constants.AF_UOM_CLASS_ABBR + "2", refUom, 0.5, 0);
                uom.Description = "Old description";
            }
        }

        private AFDatabase CreateDatabase()
        {
            AFDatabase db = StandardPISystem.Databases[Constants.AF_DATABASE_NAME];
            if (db == null)
            {
                db = StandardPISystem.Databases.Add(Constants.AF_DATABASE_NAME);
            }
            return db;
        }

        private AFCategory CreateCategory(AFCategories categories, string categoryName, int number = 1)
        {
            string compl = string.Empty;
            if (number > 1)
            {
                compl = number.ToString();
            }
            AFCategory category = categories[categoryName + compl];
            if (category == null)
            {
                category = categories.Add(categoryName + compl);
            }
            category.Description = "Original description";

            return category;
        }

        private AFTable CreateTable(AFDatabase db)
        {
            DataTable dtMyTable = new DataTable();
            dtMyTable.Locale = CultureInfo.InvariantCulture;
            AFTable myTable = db.Tables.Add(Constants.AF_TABLE_NAME);
            myTable.Description = "This is my table.";

            dtMyTable.Columns.Add("TankName", typeof(System.String));
            dtMyTable.Columns.Add("Height", typeof(System.Double));
            dtMyTable.Columns.Add("Volume", typeof(System.Double));

            DataRow drMyRow0 = dtMyTable.NewRow();
            drMyRow0["TankName"] = "TK101";
            drMyRow0["Height"] = 0;
            drMyRow0["Volume"] = 0;

            DataRow drMyRow1 = dtMyTable.NewRow();
            drMyRow1["TankName"] = "TK101";
            drMyRow1["Height"] = 1;
            drMyRow1["Volume"] = 12.4;

            DataRow drMyRow2 = dtMyTable.NewRow();
            drMyRow2["TankName"] = "TK101";
            drMyRow2["Height"] = 2;
            drMyRow2["Volume"] = 48.6;

            dtMyTable.Rows.Add(drMyRow0);
            dtMyTable.Rows.Add(drMyRow1);
            dtMyTable.Rows.Add(drMyRow2);

            // Set the Table and CachInterval Properties
            // and Set the UOM for Volume
            myTable.Table = dtMyTable;
            myTable.CacheInterval = TimeSpan.FromMinutes(10);
            myTable.SetExtendedProperty("Volume", "UOM", "US gal");
            return myTable;
        }

        private AFEnumerationSet CreateEnumerationSet(AFDatabase db)
        {
            AFEnumerationSet enumSet = db.EnumerationSets.Add(Constants.AF_ENUMERATION_SET_NAME);
            enumSet.Add("Very Good", 4);
            enumSet.Add("Good", 3);
            enumSet.Add("Bad", 2);
            enumSet.Add("Very Bad", 1);
            return enumSet;
        }

        private AFAnalysisTemplate CreateAnalysisTemplate(AFDatabase db)
        {
            var analysisTemplate = db.AnalysisTemplates.Add(Constants.AF_ANALYSIS_TEMPLATE_NAME);
            analysisTemplate.Description = "This is the old analysis template swagger description";
            return analysisTemplate;
        }

        private AFElementTemplate CreateElementTemplate(AFDatabase db)
        {
            AFElementTemplate elTmpl = db.ElementTemplates[Constants.AF_ELEMENT_TEMPLATE_NAME];
            if (elTmpl == null)
            {
                elTmpl = db.ElementTemplates.Add(Constants.AF_ELEMENT_TEMPLATE_NAME);
            }

            AFAttributeTemplate attributeTemplate = elTmpl.AttributeTemplates[Constants.AF_ATTRIBUTE_TEMPLATE_NAME];
            if (attributeTemplate == null)
            {
                attributeTemplate = elTmpl.AttributeTemplates.Add(Constants.AF_ATTRIBUTE_TEMPLATE_NAME);
                attributeTemplate.Type = typeof(Double);
                attributeTemplate.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Temperature"].UOMs["degree Celsius"];
                attributeTemplate.DataReferencePlugIn = _piSystem.DataReferencePlugIns["PI Point"];
                var childAttTmpl1 = attributeTemplate.AttributeTemplates.Add((Constants.AF_ATTRIBUTE_TEMPLATE_NAME + "Child1"));
                var childAttTmpl2 = attributeTemplate.AttributeTemplates.Add((Constants.AF_ATTRIBUTE_TEMPLATE_NAME + "Child2"));
                var childAttTmpl3 = attributeTemplate.AttributeTemplates.Add((Constants.AF_ATTRIBUTE_TEMPLATE_NAME + "Child3"));
            }
            AFAttributeTemplate attributeTemplate2 = elTmpl.AttributeTemplates["Pressure"];
            if (attributeTemplate2 == null)
            {
                attributeTemplate2 = elTmpl.AttributeTemplates.Add("Pressure");
                attributeTemplate2.Type = typeof(Double);
                attributeTemplate2.DataReferencePlugIn = _piSystem.DataReferencePlugIns["PI Point"];             
            }
            AFAttributeTemplate attributeTemplate3 = elTmpl.AttributeTemplates["Level"];
            if (attributeTemplate3 == null)
            {
                attributeTemplate3 = elTmpl.AttributeTemplates.Add("Level");
                attributeTemplate3.Type = typeof(Double);
                attributeTemplate3.DataReferencePlugIn = _piSystem.DataReferencePlugIns["PI Point"];
            }
            return elTmpl;
        }

        private AFAnalysis CreateAnalysis(AFDatabase db, AFElement el, AFCategory analysisCategory1, AFCategory analysisCategory2)
        {
            AFAttribute attribute = el.Attributes["Temperature Average"];
            AFAnalysis an = el.Analyses[Constants.AF_ANALYSIS_NAME];
            if (an == null)
            {
                an = el.Analyses.Add(Constants.AF_ANALYSIS_NAME);
                an.Description = "Analysis for Washington Temeperature Average";
                an.AnalysisRulePlugIn = _piSystem.AnalysisRulePlugIns["EventFrame"];
                an.AnalysisRule.ConfigString = "Avg2d := TagAvg('Temperature','*-2d','*');Avg1d := TagAvg('Temperature','*-1d','*');SumAvg := Avg1d+Avg2d+2;";
                an.AnalysisRule.MapVariable("SumAvg", attribute);
                an.TimeRulePlugIn = _piSystem.TimeRulePlugIns[Constants.AF_TIMERULE_NAME];
                an.TimeRule.ConfigString = "Frequency=300";
                an.SetStatus(AFStatus.Enabled);
                an.Categories.Add(analysisCategory1);
                an.Categories.Add(analysisCategory2);
            }
            return an;
        }

        private AFElement CreateElementAndAttributes(AFDatabase db, AFCategory elementCategory, AFCategory attributeCategory)
        {

            AFElement el2 = db.Elements[Constants.AF_ELEMENT_NAME + "2"];
            if (el2 == null)
            {
                el2 = db.Elements.Add(Constants.AF_ELEMENT_NAME + "2");
            }


            AFElement el = db.Elements[Constants.AF_ELEMENT_NAME];
            if (el == null)
            {
                el = db.Elements.Add(Constants.AF_ELEMENT_NAME);
                el.Elements.Add(Constants.AF_ELEMENT_NAME + "Child1");
                el.Elements.Add(Constants.AF_ELEMENT_NAME + "Child2");
                el.Categories.Add(elementCategory);

            }


            AFAttribute tempAvg = el.Attributes["Temperature Average"];
            if (tempAvg == null)
            {
                tempAvg = el.Attributes.Add("Temperature Average");
                tempAvg.Type = typeof(Double);
                tempAvg.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Temperature"].UOMs["degree Celsius"];
            }

            AFAttribute temp = el.Attributes["Temperature"];
            if (temp == null)
            {
                temp = el.Attributes.Add("Temperature");
                temp.Type = typeof(Double);
                temp.DataReferencePlugIn = _piSystem.DataReferencePlugIns["PI Point"];
                temp.ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\sinusoid";
                temp.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Temperature"].UOMs["degree Celsius"];
                AFAttribute limitHiAttr = temp.Attributes.Add(AFAttributeTrait.LimitHi.Abbreviation);
                limitHiAttr.Trait = AFAttributeTrait.LimitHi;
                limitHiAttr.SetValue(100, temp.DefaultUOM);

            }


            AFAttribute attribute = el.Attributes[Constants.AF_ATTRIBUTE_NAME];
            if (attribute == null)
            {
                attribute = el.Attributes.Add(Constants.AF_ATTRIBUTE_NAME);
                attribute.Type = typeof(Double);
                attribute.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Temperature"].UOMs["degree Celsius"];
                attribute.Categories.Add(attributeCategory);
                AFAttribute childAttribute = attribute.Attributes.Add(Constants.AF_ATTRIBUTE_NAME + "Child1");
                AFAttribute childAttribute2 = attribute.Attributes.Add(Constants.AF_ATTRIBUTE_NAME + "Child2");
                AFAttribute limitHiAttr = attribute.Attributes.Add(AFAttributeTrait.LimitHi.Abbreviation);
                limitHiAttr.Trait = AFAttributeTrait.LimitHi;
                limitHiAttr.SetValue(100, temp.DefaultUOM);
            }

            return el;
        }

        private AFEventFrame CreateEventFrame(AFDatabase db, AFElementTemplate eventFrameTemplate, AFCategory elementCategory)
        {
            AFEventFrame ef = null;
            if (eventFrameTemplate == null)
            {
                AFElement el2 = db.Elements[Constants.AF_ELEMENT_NAME + "2"];
                AFElement el = db.Elements[Constants.AF_ELEMENT_NAME];
                AFTime startTime = new AFTime(DateTime.Now.AddDays(-1));
                ef = new AFEventFrame(db, Constants.AF_EVENT_FRAME_NAME);
                ef.ReferencedElements.Add(el);
                ef.ReferencedElements.Add(el2);
                ef.PrimaryReferencedElement = el;
                ef.SetStartTime(startTime);
                ef.CanBeAcknowledged = true;
                ef.SetEndTime(new AFTime("*"));
                ef.Categories.Add(elementCategory);
                AFEventFrame ef1 = ef.EventFrames.Add(Constants.AF_EVENT_FRAME_NAME + "Child1");
                AFEventFrame ef2 = ef.EventFrames.Add(Constants.AF_EVENT_FRAME_NAME + "Child2");
                ef.Attributes.Add(Constants.AF_ATTRIBUTE_NAME);
                IList<AFAnnotation> annotations = el.GetAnnotations();
                AFAnnotation ann = new AFAnnotation(ef);
                ann.Name = Constants.AF_EVENT_FRAME_ANNOTATION_NAME;
                ann.Value = "Sample value for annotation";
                ann.Save();
            }
            else
            {
                AFElement myTank1 = db.Elements["Tank 1"];
                AFElement myTank2 = db.Elements["Tank 2"];
                AFTime startTime = new AFTime("*-1d");
                ef = new AFEventFrame(db, "Tank Level 1", eventFrameTemplate);
                ef.ReferencedElements.Add(myTank1);
                ef.ReferencedElements.Add(myTank2);
                ef.PrimaryReferencedElement = myTank1;
                ef.SetStartTime(AFTime.Now);
                ef.CheckIn();
                AFTime endTime = AFTime.Now;
                ef.SetEndTime(endTime);
            }
            return ef;
        }

        private AFElementTemplate CreateEventFrameTemplate(AFDatabase db)
        {
            AFElementTemplate evTemplate = db.ElementTemplates[Constants.AF_EVENT_FRAME_TEMPLATE_NAME];
            if (evTemplate == null)
            {
                evTemplate = db.ElementTemplates.Add("TankEventFrameTemplate");
                evTemplate.Description = "Tank Event Frame Template!";
                evTemplate.InstanceType = typeof(AFEventFrame);

                AFAttributeTemplate Level = evTemplate.AttributeTemplates.Add("Level");
                Level.Type = typeof(double);
                Level.DataReferencePlugIn = Level.PISystem.DataReferencePlugIns["PI Point"];
                Level.ConfigString = @".\Elements[.]|Level";
                Level.Description = "Level of the tank";
                Level.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Ratio"].UOMs["percent"];


                AFAttributeTemplate Pressure = evTemplate.AttributeTemplates.Add("Pressure");
                Pressure.Type = typeof(double);
                Pressure.DataReferencePlugIn = Level.PISystem.DataReferencePlugIns["PI Point"];
                Pressure.ConfigString = @".\Elements[.]|Pressure;TimeRangeMethod=StartTime";
                Pressure.Description = "Pressure of the tank";
                Pressure.DefaultUOM = _piSystem.UOMDatabase.UOMClasses["Pressure"].UOMs["pascal"];

                evTemplate.DefaultAttribute = Level;
            }
            return evTemplate;
        }

        private void CreateElementForStreamSet(AFDatabase db)
        {
            AFElement streamSetElement = db.Elements.Add(Constants.AF_ELEMENT_STREAMSET_NAME);
            var list = new List<string>() { "sinusoid", "sinusoidu", "cdt158" };

            foreach (string attributeName in list)
            {
                AFAttribute attr = streamSetElement.Attributes.Add(attributeName);
                attr.Type = typeof(Double);
                attr.DataReferencePlugIn = _piSystem.DataReferencePlugIns["PI Point"];
                attr.ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\" + attributeName;
            }
        }


        private void CreateElementFromTemplate(AFDatabase db, AFElementTemplate elementTemplate)
        {
            AFElement element1= db.Elements.Add("Tank 1", elementTemplate);
            element1.Attributes["Pressure"].ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\sinusoid";
            element1.Attributes["Level"].ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\cdt158";
            AFElement element2 = db.Elements.Add("Tank 2", elementTemplate);
            element2.Attributes["Pressure"].ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\sinusoidu";
            element2.Attributes["Level"].ConfigString = @"\\" + Constants.DATA_SERVER_NAME + @"\sinusoid";
        }

        public void CreateSampleDatabaseForTests()
        {
            DeleteSampleDatabaseForTests();
            CreateSecurityIdentities();
            CreateSecurityMappings();
            CreateUOMClasses();
            AFDatabase db = CreateDatabase();


            AFCategory analysisCategory1 = CreateCategory(db.AnalysisCategories, Constants.AF_ANALYSIS_CATEGORY_NAME, 1);
            AFCategory analysisCategory2 = CreateCategory(db.AnalysisCategories, Constants.AF_ANALYSIS_CATEGORY_NAME, 2);
            AFCategory tableCategory1 = CreateCategory(db.TableCategories, Constants.AF_TABLE_CATEGORY_NAME, 1);
            AFCategory tableCategory2 = CreateCategory(db.TableCategories, Constants.AF_TABLE_CATEGORY_NAME, 2);
            AFCategory attributeCategory1 = CreateCategory(db.AttributeCategories, Constants.AF_ATTRIBUTE_CATEGORY_NAME, 1);
            AFCategory attributeCategory2 = CreateCategory(db.AttributeCategories, Constants.AF_ATTRIBUTE_CATEGORY_NAME, 2);
            AFCategory elementCategory1 = CreateCategory(db.ElementCategories, Constants.AF_ELEMENT_CATEGORY_NAME, 1);
            AFCategory elementCategory2 = CreateCategory(db.ElementCategories, Constants.AF_ELEMENT_CATEGORY_NAME, 2);

            AFTable table = CreateTable(db);
            table.Categories.Add(tableCategory1);
            AFEnumerationSet enumSet = CreateEnumerationSet(db);



            AFElementTemplate elementTemplate = CreateElementTemplate(db);
            CreateElementFromTemplate(db, elementTemplate);
            AFElement el = CreateElementAndAttributes(db, elementCategory1, attributeCategory1);

            CreateElementForStreamSet(db);


            AFAnalysisTemplate analysisTemplate = CreateAnalysisTemplate(db);
            AFAnalysis an = CreateAnalysis(db, el, analysisCategory1, analysisCategory2);


            AFEventFrame ef = CreateEventFrame(db, null, elementCategory1);
            AFElementTemplate eventFrameTemplate = CreateEventFrameTemplate(db);
            AFEventFrame ef2 = CreateEventFrame(db, eventFrameTemplate, elementCategory1);

            db.CheckIn();
        }




        private void DeleteSecurityIdentities()
        {
            AFSecurityIdentity myIdentity = _piSystem.SecurityIdentities["SwaggerUser"];
            if (myIdentity != null)
            {
                _piSystem.SecurityIdentities.Remove(myIdentity);
            }
        }
        private void DeleteSecurityMappings()
        {
            if (myMapping != null)
            {
                _piSystem.SecurityMappings.Remove(myMapping);
            }
        }
        private void DeleteUOMClasses()
        {
            UOMClass uomClass = StandardPISystem.UOMDatabase.UOMClasses[Constants.AF_UOM_CLASS_NAME];
            if (uomClass != null)
            {
                StandardPISystem.UOMDatabase.UOMClasses.Remove(uomClass);
            }

            UOM uom = StandardPISystem.UOMDatabase.UOMs[Constants.AF_UOM_NAME];
            if (uom != null)
            {
                StandardPISystem.UOMDatabase.UOMs.Remove(uom);
            }

            UOM uom2 = StandardPISystem.UOMDatabase.UOMs[Constants.AF_UOM_CLASS_UNIT + "2"];
            if (uom2 != null)
            {
                StandardPISystem.UOMDatabase.UOMs.Remove(uom2);
            }

            UOM uom4 = StandardPISystem.UOMDatabase.UOMs[Constants.AF_UOM_CLASS_UNIT + "4"];
            if (uom4 != null)
            {
                StandardPISystem.UOMDatabase.UOMs.Remove(uom4);
            }

        }

        private void DeleteDatabase()
        {
            AFDatabase db = StandardPISystem.Databases[Constants.AF_DATABASE_NAME];
            if (db != null)
            {
                _piSystem.Databases.Remove(db);
            }
        }


        internal void DeleteSampleDatabaseForTests()
        {
            DeleteDatabase();
            DeleteSecurityIdentities();
            DeleteSecurityMappings();
            DeleteUOMClasses();
            _piSystem.CheckIn();
        }

    }
}
