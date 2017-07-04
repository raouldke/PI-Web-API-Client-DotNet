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
    /// PISearchSearchIndexPageLinks
    /// </summary>
    [DataContract]
    public partial class PISearchSearchIndexPageLinks :  IEquatable<PISearchSearchIndexPageLinks>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PISearchSearchIndexPageLinks" /> class.
        /// </summary>
        /// <param name="Self">Self.</param>
        /// <param name="Query">Query.</param>
        /// <param name="Sources">Sources.</param>
        /// <param name="Version">Version.</param>
        /// <param name="Info">Info.</param>
        /// <param name="Metrics">Metrics.</param>
        /// <param name="Settings">Settings.</param>
        /// <param name="Admin">Admin.</param>
        public PISearchSearchIndexPageLinks(string Self = null, string Query = null, string Sources = null, string Version = null, string Info = null, string Metrics = null, string Settings = null, string Admin = null)
        {
            this.Self = Self;
            this.Query = Query;
            this.Sources = Sources;
            this.Version = Version;
            this.Info = Info;
            this.Metrics = Metrics;
            this.Settings = Settings;
            this.Admin = Admin;
        }
        
        /// <summary>
        /// Gets or Sets Self
        /// </summary>
        [DataMember(Name="Self", EmitDefaultValue=false)]
        public string Self { get; set; }
        /// <summary>
        /// Gets or Sets Query
        /// </summary>
        [DataMember(Name="Query", EmitDefaultValue=false)]
        public string Query { get; set; }
        /// <summary>
        /// Gets or Sets Sources
        /// </summary>
        [DataMember(Name="Sources", EmitDefaultValue=false)]
        public string Sources { get; set; }
        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="Version", EmitDefaultValue=false)]
        public string Version { get; set; }
        /// <summary>
        /// Gets or Sets Info
        /// </summary>
        [DataMember(Name="Info", EmitDefaultValue=false)]
        public string Info { get; set; }
        /// <summary>
        /// Gets or Sets Metrics
        /// </summary>
        [DataMember(Name="Metrics", EmitDefaultValue=false)]
        public string Metrics { get; set; }
        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name="Settings", EmitDefaultValue=false)]
        public string Settings { get; set; }
        /// <summary>
        /// Gets or Sets Admin
        /// </summary>
        [DataMember(Name="Admin", EmitDefaultValue=false)]
        public string Admin { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PISearchSearchIndexPageLinks {\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  Sources: ").Append(Sources).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("  Metrics: ").Append(Metrics).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
            sb.Append("  Admin: ").Append(Admin).Append("\n");
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
            return this.Equals(obj as PISearchSearchIndexPageLinks);
        }

        /// <summary>
        /// Returns true if PISearchSearchIndexPageLinks instances are equal
        /// </summary>
        /// <param name="other">Instance of PISearchSearchIndexPageLinks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PISearchSearchIndexPageLinks other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Self == other.Self ||
                    this.Self != null &&
                    this.Self.Equals(other.Self)
                ) && 
                (
                    this.Query == other.Query ||
                    this.Query != null &&
                    this.Query.Equals(other.Query)
                ) && 
                (
                    this.Sources == other.Sources ||
                    this.Sources != null &&
                    this.Sources.Equals(other.Sources)
                ) && 
                (
                    this.Version == other.Version ||
                    this.Version != null &&
                    this.Version.Equals(other.Version)
                ) && 
                (
                    this.Info == other.Info ||
                    this.Info != null &&
                    this.Info.Equals(other.Info)
                ) && 
                (
                    this.Metrics == other.Metrics ||
                    this.Metrics != null &&
                    this.Metrics.Equals(other.Metrics)
                ) && 
                (
                    this.Settings == other.Settings ||
                    this.Settings != null &&
                    this.Settings.Equals(other.Settings)
                ) && 
                (
                    this.Admin == other.Admin ||
                    this.Admin != null &&
                    this.Admin.Equals(other.Admin)
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
                if (this.Self != null)
                    hash = hash * 59 + this.Self.GetHashCode();
                if (this.Query != null)
                    hash = hash * 59 + this.Query.GetHashCode();
                if (this.Sources != null)
                    hash = hash * 59 + this.Sources.GetHashCode();
                if (this.Version != null)
                    hash = hash * 59 + this.Version.GetHashCode();
                if (this.Info != null)
                    hash = hash * 59 + this.Info.GetHashCode();
                if (this.Metrics != null)
                    hash = hash * 59 + this.Metrics.GetHashCode();
                if (this.Settings != null)
                    hash = hash * 59 + this.Settings.GetHashCode();
                if (this.Admin != null)
                    hash = hash * 59 + this.Admin.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
