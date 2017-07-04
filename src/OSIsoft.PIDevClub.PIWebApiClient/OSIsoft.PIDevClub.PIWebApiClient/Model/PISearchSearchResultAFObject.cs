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
    /// PISearchSearchResultAFObject
    /// </summary>
    [DataContract]
    public partial class PISearchSearchResultAFObject :  IEquatable<PISearchSearchResultAFObject>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PISearchSearchResultAFObject" /> class.
        /// </summary>
        /// <param name="Name">Gets or sets the name of this object.</param>
        /// <param name="Description">Gets or sets a description for this object.</param>
        /// <param name="UniqueId">Gets or sets the UniqueId of this object.</param>
        /// <param name="Path">Gets or sets the path of this object.</param>
        /// <param name="Links">Gets or sets the links for this object.</param>
        public PISearchSearchResultAFObject(string Name = null, string Description = null, string UniqueId = null, string Path = null, Dictionary<string, string> Links = null)
        {
            this.Name = Name;
            this.Description = Description;
            this.UniqueId = UniqueId;
            this.Path = Path;
            this.Links = Links;
        }
        
        /// <summary>
        /// Gets or sets the name of this object
        /// </summary>
        /// <value>Gets or sets the name of this object</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a description for this object
        /// </summary>
        /// <value>Gets or sets a description for this object</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the UniqueId of this object
        /// </summary>
        /// <value>Gets or sets the UniqueId of this object</value>
        [DataMember(Name="UniqueId", EmitDefaultValue=false)]
        public string UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the path of this object
        /// </summary>
        /// <value>Gets or sets the path of this object</value>
        [DataMember(Name="Path", EmitDefaultValue=false)]
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets the links for this object
        /// </summary>
        /// <value>Gets or sets the links for this object</value>
        [DataMember(Name="Links", EmitDefaultValue=false)]
        public Dictionary<string, string> Links { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PISearchSearchResultAFObject {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  UniqueId: ").Append(UniqueId).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
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
            return this.Equals(obj as PISearchSearchResultAFObject);
        }

        /// <summary>
        /// Returns true if PISearchSearchResultAFObject instances are equal
        /// </summary>
        /// <param name="other">Instance of PISearchSearchResultAFObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PISearchSearchResultAFObject other)
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
                    this.UniqueId == other.UniqueId ||
                    this.UniqueId != null &&
                    this.UniqueId.Equals(other.UniqueId)
                ) && 
                (
                    this.Path == other.Path ||
                    this.Path != null &&
                    this.Path.Equals(other.Path)
                ) && 
                (
                    this.Links == other.Links ||
                    this.Links != null &&
                    this.Links.SequenceEqual(other.Links)
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
                if (this.UniqueId != null)
                    hash = hash * 59 + this.UniqueId.GetHashCode();
                if (this.Path != null)
                    hash = hash * 59 + this.Path.GetHashCode();
                if (this.Links != null)
                    hash = hash * 59 + this.Links.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}