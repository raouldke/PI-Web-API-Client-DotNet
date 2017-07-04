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
    /// PISearchSearchIndexPage
    /// </summary>
    [DataContract]
    public partial class PISearchSearchIndexPage :  IEquatable<PISearchSearchIndexPage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PISearchSearchIndexPage" /> class.
        /// </summary>
        /// <param name="Links">Links.</param>
        public PISearchSearchIndexPage(PISearchSearchIndexPageLinks Links = null)
        {
            this.Links = Links;
        }
        
        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name="Links", EmitDefaultValue=false)]
        public PISearchSearchIndexPageLinks Links { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PISearchSearchIndexPage {\n");
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
            return this.Equals(obj as PISearchSearchIndexPage);
        }

        /// <summary>
        /// Returns true if PISearchSearchIndexPage instances are equal
        /// </summary>
        /// <param name="other">Instance of PISearchSearchIndexPage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PISearchSearchIndexPage other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Links == other.Links ||
                    this.Links != null &&
                    this.Links.Equals(other.Links)
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