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
    /// PISearchSearchResultParent
    /// </summary>
    [DataContract]
    public partial class PISearchSearchResultParent :  IEquatable<PISearchSearchResultParent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PISearchSearchResultParent" /> class.
        /// </summary>
        /// <param name="ParentPath">Path of the parent element, or \\\\afserver\\afdatabase for a root element.</param>
        /// <param name="Paths">The possible paths for this parent.</param>
        /// <param name="NoParentInfo">NoParentInfo.</param>
        /// <param name="Plottable">Number of plottable attributes of the parent element.</param>
        public PISearchSearchResultParent(string ParentPath = null, List<string> Paths = null, bool? NoParentInfo = null, int? Plottable = null)
        {
            this.ParentPath = ParentPath;
            this.Paths = Paths;
            this.NoParentInfo = NoParentInfo;
            this.Plottable = Plottable;
        }
        
        /// <summary>
        /// Path of the parent element, or \\\\afserver\\afdatabase for a root element
        /// </summary>
        /// <value>Path of the parent element, or \\\\afserver\\afdatabase for a root element</value>
        [DataMember(Name="ParentPath", EmitDefaultValue=false)]
        public string ParentPath { get; set; }
        /// <summary>
        /// The possible paths for this parent
        /// </summary>
        /// <value>The possible paths for this parent</value>
        [DataMember(Name="Paths", EmitDefaultValue=false)]
        public List<string> Paths { get; set; }
        /// <summary>
        /// Gets or Sets NoParentInfo
        /// </summary>
        [DataMember(Name="NoParentInfo", EmitDefaultValue=false)]
        public bool? NoParentInfo { get; set; }
        /// <summary>
        /// Number of plottable attributes of the parent element
        /// </summary>
        /// <value>Number of plottable attributes of the parent element</value>
        [DataMember(Name="Plottable", EmitDefaultValue=false)]
        public int? Plottable { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PISearchSearchResultParent {\n");
            sb.Append("  ParentPath: ").Append(ParentPath).Append("\n");
            sb.Append("  Paths: ").Append(Paths).Append("\n");
            sb.Append("  NoParentInfo: ").Append(NoParentInfo).Append("\n");
            sb.Append("  Plottable: ").Append(Plottable).Append("\n");
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
            return this.Equals(obj as PISearchSearchResultParent);
        }

        /// <summary>
        /// Returns true if PISearchSearchResultParent instances are equal
        /// </summary>
        /// <param name="other">Instance of PISearchSearchResultParent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PISearchSearchResultParent other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ParentPath == other.ParentPath ||
                    this.ParentPath != null &&
                    this.ParentPath.Equals(other.ParentPath)
                ) && 
                (
                    this.Paths == other.Paths ||
                    this.Paths != null &&
                    this.Paths.SequenceEqual(other.Paths)
                ) && 
                (
                    this.NoParentInfo == other.NoParentInfo ||
                    this.NoParentInfo != null &&
                    this.NoParentInfo.Equals(other.NoParentInfo)
                ) && 
                (
                    this.Plottable == other.Plottable ||
                    this.Plottable != null &&
                    this.Plottable.Equals(other.Plottable)
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
                if (this.ParentPath != null)
                    hash = hash * 59 + this.ParentPath.GetHashCode();
                if (this.Paths != null)
                    hash = hash * 59 + this.Paths.GetHashCode();
                if (this.NoParentInfo != null)
                    hash = hash * 59 + this.NoParentInfo.GetHashCode();
                if (this.Plottable != null)
                    hash = hash * 59 + this.Plottable.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
