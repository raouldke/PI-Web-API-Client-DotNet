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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    public class Constants
    {
        public const string BASE_URL = "https://marc-web-sql.marc.net/piwebapi";
        public const string DATA_SERVER_NAME = "MARC-PI2016";
        public const string DATA_SERVER_PATH = @"\\" + DATA_SERVER_NAME;

        public const string PIPOINT_CREATE_NAME = "PIPOINT-PIWEBAPI-SWAGGER-TEST";
        public const string ENUMERATIONSET_CREATE_NAME = "DigitalSwaggerEnum";
        public const string PIWEBAPI_CONFIGURATION_ELEMENT_PATH = @"\\" + AF_SERVER_NAME + @"\Configuration\OSIsoft\PI Web API\MARC-WEB-SQL\System Configuration";
        public const string PIWEBAPI_CONFIGURATION_CORSEXPHEADERS = "CorsExposedHeaders";
        public const string PIWEBAPI_CONFIGURATION_CORSMETHODS = "CorsMethods";
        public const string PIWEBAPI_CONFIGURATION_CORSEACHSCANINTERVALS = "SearchScanInterval";

        public const string TIME_START = "*-1d";
        public const string TIME_END = "*";
        public const string TIME_INTERVAL = "1h";
        public const int TIME_INTERVALS = 20;

        public const string AF_SERVER_NAME = "MARC-PI2016";
        public const string AF_SERVER_PATH = @"\\" + AF_SERVER_NAME;

        public const string AF_DATABASE_NAME = "SwaggerDb";
        public const string AF_DATABASE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME;

        public const string AF_ELEMENT_NAME = "RootElement";
        public const string AF_ELEMENT_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\" + AF_ELEMENT_NAME;
        public const string AF_ELEMENT_STREAMSET_NAME = "ElementForStreamSet";
        public const string AF_ELEMENT_STREAMSET_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\" + AF_ELEMENT_STREAMSET_NAME;
        public const string AF_ELEMENT_CATEGORY_NAME = "SwaggerCategoryElementTest";
        public const string AF_ELEMENT_CATEGORY_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\CategoriesElement[" + AF_ELEMENT_CATEGORY_NAME + "]";
        public const string AF_ELEMENT_TEMPLATE_NAME = "SwaggerElementTemplateTest";
        public const string AF_ELEMENT_TEMPLATE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\ElementTemplates[" + AF_ELEMENT_TEMPLATE_NAME + "]";

        public const string AF_ATTRIBUTE_NAME = "SwaggerAttributeTest";
        public const string AF_ATTRIBUTE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\" + AF_ELEMENT_NAME + "|" + AF_ATTRIBUTE_NAME;
        public const string AF_ATTRIBUTE_TEMPLATE_NAME = "SwaggerAttributeTemplateTest";
        public const string AF_ATTRIBUTE_TEMPLATE_PATH = AF_ELEMENT_TEMPLATE_PATH + "|" + AF_ATTRIBUTE_TEMPLATE_NAME;
        public const string AF_ATTRIBUTE_CATEGORY_NAME = "SwaggerAttributeCategory";
        public const string AF_ATTRIBUTE_CATEGORY_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\CategoriesAttribute[" + AF_ATTRIBUTE_CATEGORY_NAME + "]";


        public const string AF_ANALYSIS_NAME = "TestAnalysis";
        public const string AF_ANALYSIS_TEMPLATE_NAME = "TestTemplateAnalysis";
        public const string AF_ANALYSIS_TEMPLATE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\AnalysisTemplates[" + AF_ANALYSIS_TEMPLATE_NAME + "]";
        public const string AF_ANALYSIS_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\" + AF_ELEMENT_NAME + "\\Analyses[" + AF_ANALYSIS_NAME + "]";
        public const string AF_ANALYSIS_RULE_PLUGIN_PATH = @"\\" + AF_SERVER_NAME + @"\PlugInsAnalysisRule[Comparison]";
        public const string AF_ANALYSIS_RULE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\" + AF_ELEMENT_NAME + "\\Analyses[" + AF_ANALYSIS_NAME + "]\\AnalysisRule";
        public const string AF_ANALYSIS_CATEGORY_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\CategoriesAnalysis[" + AF_ANALYSIS_CATEGORY_NAME + "]";
        public const string AF_ANALYSIS_CATEGORY_NAME = "AnalysisCategory1";

        public const string AF_TIMERULE_NAME = "Periodic";
        public const string AF_TIMERULE_PATH = AF_ANALYSIS_PATH + "\\TimeRule";
        public const string AF_TABLE_NAME = "SwaggerTestTable";
        public const string AF_TABLE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\Tables[" + AF_TABLE_NAME + "]";
        public const string AF_TABLE_CATEGORY_NAME = "TableSwaggerCategory";
        public const string AF_TABLE_CATEGORY_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\CategoriesTable[" + AF_TABLE_CATEGORY_NAME + "]";



        public const string AF_SECURITY_MAPPING_NAME = "SwaggerMapping";
        public const string AF_SECURITY_MAPPING_PATH = @"\\" + AF_SERVER_NAME + "\\SecurityMappings[" + AF_SECURITY_MAPPING_NAME + "]";
        public const string AF_SECURITY_IDENTITY_NAME = "SwaggerIdentity";
        public const string AF_SECURITY_IDENTITY_PATH = @"\\" + AF_SERVER_NAME + "\\SecurityIdentities[" + AF_SECURITY_IDENTITY_NAME + "]";

        public const string AF_ENUMERATION_VALUE_NAME = "Good";
        public const string AF_ENUMERATION_VALUE_PATH = AF_ENUMERATION_SET_PATH + "\\" + AF_ENUMERATION_VALUE_NAME;
        public const string AF_ENUMERATION_SET_NAME = "SwaggerEnumerationSet";
        public const string AF_ENUMERATION_SET_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\EnumerationSets[" + AF_ENUMERATION_SET_NAME + "]";
        public const string AF_EVENT_FRAME_NAME = "SwaggerEventFrame";
        public const string AF_EVENT_FRAME_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\EventFrames[" + AF_EVENT_FRAME_NAME + "]";
        public const string AF_EVENT_FRAME_TEMPLATE_NAME = "TankEventFrameTemplate";
        public const string AF_EVENT_FRAME_TEMPLATE_PATH = @"\\" + AF_SERVER_NAME + "\\" + AF_DATABASE_NAME + "\\ElementTemplates[" + AF_EVENT_FRAME_TEMPLATE_NAME + "]";

        public const string AF_EVENT_FRAME_ANNOTATION_NAME = "SwaggerAnnotationName";


        public const string AF_UOM_CLASS_NAME = "SwaggerUnitClass";
        public const string AF_UOM_CLASS_PATH = AF_SERVER_PATH + @"\UOMDatabase\UOMClasses[" + AF_UOM_CLASS_NAME + "]";
        public const string AF_UOM_CLASS_UNIT = "SwaggerDefault";
        public const string AF_UOM_CLASS_ABBR = "swg";



        public const string AF_UOM_NAME = AF_UOM_CLASS_UNIT + "3";
        public const string AF_UOM_PATH = AF_SERVER_PATH + @"\UOMDatabase\" + AF_UOM_NAME;

        //pi wEB API help shows CategoriesAttribute instead

    }
}
