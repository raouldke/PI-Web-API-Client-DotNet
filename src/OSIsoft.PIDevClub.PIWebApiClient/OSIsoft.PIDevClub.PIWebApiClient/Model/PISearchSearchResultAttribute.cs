/* 
 * PI Web API 2016 R2 Swagger definition
 *
 * RESTful client for PI Web API 2016 R2
 *
 * OpenAPI spec version: v1
 * Contact: pidevclub@osisoft.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace OSIsoft.PIDevClub.PIWebApiClient.Model
{
    /// <summary>
    /// PISearchSearchResultAttribute
    /// </summary>
    [DataContract]
    public partial class PISearchSearchResultAttribute :  IEquatable<PISearchSearchResultAttribute>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PISearchSearchResultAttribute" /> class.
        /// </summary>
        /// <param name="Name">Gets or sets the name of this attribute.</param>
        /// <param name="Description">Gets or sets the description of this attribute.</param>
        /// <param name="DataType">Gets or sets the datatype for this attribute.</param>
        /// <param name="UoM">Gets or sets the unit of measure for this attribute.</param>
        /// <param name="Value">Gets or sets the value of this attribute.</param>
        /// <param name="Categories">Gets or sets the collection of categories.</param>
        /// <param name="Attributes">Gets or sets the collection of child attributes for this attribute.</param>
        /// <param name="WebID">Gets or sets the WebID unique to this attribute.</param>
        public PISearchSearchResultAttribute(string Name = null, string Description = null, string DataType = null, string UoM = null, Object Value = null, List<PISearchSearchResultAFObject> Categories = null, List<PISearchSearchResultAttribute> Attributes = null, string WebID = null)
        {
            this.Name = Name;
            this.Description = Description;
            this.DataType = DataType;
            this.UoM = UoM;
            this.Value = Value;
            this.Categories = Categories;
            this.Attributes = Attributes;
            this.WebID = WebID;
        }
        
        /// <summary>
        /// Gets or sets the name of this attribute
        /// </summary>
        /// <value>Gets or sets the name of this attribute</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description of this attribute
        /// </summary>
        /// <value>Gets or sets the description of this attribute</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the datatype for this attribute
        /// </summary>
        /// <value>Gets or sets the datatype for this attribute</value>
        [DataMember(Name="DataType", EmitDefaultValue=false)]
        public string DataType { get; set; }
        /// <summary>
        /// Gets or sets the unit of measure for this attribute
        /// </summary>
        /// <value>Gets or sets the unit of measure for this attribute</value>
        [DataMember(Name="UoM", EmitDefaultValue=false)]
        public string UoM { get; set; }
        /// <summary>
        /// Gets or sets the value of this attribute
        /// </summary>
        /// <value>Gets or sets the value of this attribute</value>
        [DataMember(Name="Value", EmitDefaultValue=false)]
        public Object Value { get; set; }
        /// <summary>
        /// Gets or sets the collection of categories
        /// </summary>
        /// <value>Gets or sets the collection of categories</value>
        [DataMember(Name="Categories", EmitDefaultValue=false)]
        public List<PISearchSearchResultAFObject> Categories { get; set; }
        /// <summary>
        /// Gets or sets the collection of child attributes for this attribute
        /// </summary>
        /// <value>Gets or sets the collection of child attributes for this attribute</value>
        [DataMember(Name="Attributes", EmitDefaultValue=false)]
        public List<PISearchSearchResultAttribute> Attributes { get; set; }
        /// <summary>
        /// Gets or sets the WebID unique to this attribute
        /// </summary>
        /// <value>Gets or sets the WebID unique to this attribute</value>
        [DataMember(Name="WebID", EmitDefaultValue=false)]
        public string WebID { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PISearchSearchResultAttribute {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DataType: ").Append(DataType).Append("\n");
            sb.Append("  UoM: ").Append(UoM).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Categories: ").Append(Categories).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("  WebID: ").Append(WebID).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as PISearchSearchResultAttribute);
        }

        /// <summary>
        /// Returns true if PISearchSearchResultAttribute instances are equal
        /// </summary>
        /// <param name="other">Instance of PISearchSearchResultAttribute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PISearchSearchResultAttribute other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.DataType == other.DataType ||
                    this.DataType != null &&
                    this.DataType.Equals(other.DataType)
                ) && 
                (
                    this.UoM == other.UoM ||
                    this.UoM != null &&
                    this.UoM.Equals(other.UoM)
                ) && 
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
                ) && 
                (
                    this.Categories == other.Categories ||
                    this.Categories != null &&
                    this.Categories.SequenceEqual(other.Categories)
                ) && 
                (
                    this.Attributes == other.Attributes ||
                    this.Attributes != null &&
                    this.Attributes.SequenceEqual(other.Attributes)
                ) && 
                (
                    this.WebID == other.WebID ||
                    this.WebID != null &&
                    this.WebID.Equals(other.WebID)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DataType != null)
                    hash = hash * 59 + this.DataType.GetHashCode();
                if (this.UoM != null)
                    hash = hash * 59 + this.UoM.GetHashCode();
                if (this.Value != null)
                    hash = hash * 59 + this.Value.GetHashCode();
                if (this.Categories != null)
                    hash = hash * 59 + this.Categories.GetHashCode();
                if (this.Attributes != null)
                    hash = hash * 59 + this.Attributes.GetHashCode();
                if (this.WebID != null)
                    hash = hash * 59 + this.WebID.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
