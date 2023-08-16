using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace odata_error.Models
{

    /// <summary>
    /// Represents the store table ODataTest.ConfigNode, the entity set name is ConfigNodes
    /// </summary>
    [Table("ConfigNode")]
    public partial class ConfigNode
    {

        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.Id
        /// </summary>
        [Key]
        [Column("Id")]
        [Required]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.ParentId
        /// </summary>
        [Column("ParentId")]
        [DataMember]
        public virtual int? ParentId { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.Code
        /// </summary>
        [Column("Code", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [Required]
        [DataMember]
        public virtual string? Code { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.Value
        /// </summary>
        [Column("Value", TypeName = "varchar(2000)")]
        [DataMember]
        public virtual string? Value { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.Description
        /// </summary>
        [Column("Description", TypeName = "varchar(200)")]
        [MaxLength(200)]
        [DataMember]
        public virtual string? Description { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.SortPriority
        /// </summary>
        [Column("SortPriority")]
        [DataMember]
        public virtual short? SortPriority { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.IsDefault
        /// </summary>
        [Column("IsDefault")]
        [DataMember]
        [DefaultValue(false)]
        public virtual bool? IsDefault { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.IsDisabled
        /// </summary>
        [Column("IsDisabled")]
        [DataMember]
        [DefaultValue(false)]
        public virtual bool? IsDisabled { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.ParentCode
        /// </summary>
        [Column("ParentCode", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        public virtual string? ParentCode { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.IsSystem
        /// </summary>
        [Column("IsSystem")]
        [Required]
        [DataMember]
        public virtual bool IsSystem { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.ValueTypeKey
        /// </summary>
        [Column("ValueTypeKey", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        [DefaultValue("ValueType")]
        public virtual string? ValueTypeKey { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.ValueTypeCode
        /// </summary>
        [Column("ValueTypeCode", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        public virtual string? ValueTypeCode { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.CodeTypeKey
        /// </summary>
        [Column("CodeTypeKey", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        [DefaultValue("CodeType")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual string? CodeTypeKey { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.ConfigNode.CodeTypeCode
        /// </summary>
        [Column("CodeTypeCode", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        public virtual string? CodeTypeCode { get; set; }


        /// <summary>
        /// Represents foreign key 1:1 relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.ParentId &lt;==&gt; ConfigNode.Id</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [ForeignKey(nameof(ConfigNode.ParentId))]
        public virtual ConfigNode? Parent { get; set; }


        /// <summary>
        /// Represents foreign key 1:1 relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.ValueTypeKey &lt;==&gt; ConfigNode.ParentCode</item>
        /// <item>ConfigNode.ValueTypeCode &lt;==&gt; ConfigNode.Code</item>
        /// </list>
        /// </remarks>
        [DataMember]
        public virtual ConfigNode? ValueType { get; set; }


        /// <summary>
        /// Represents foreign key 1:1 relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.CodeTypeKey &lt;==&gt; ConfigNode.ParentCode</item>
        /// <item>ConfigNode.CodeTypeCode &lt;==&gt; ConfigNode.Code</item>
        /// </list>
        /// </remarks>
        [DataMember]
        public virtual ConfigNode? CodeType { get; set; }


        /// <summary>
        /// Represents foreign key 1:M relationship from ConfigNode to AzureClassUser
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.ParentCode &lt;==&gt; AzureClassUser.UserClassKey</item>
        /// <item>ConfigNode.Code &lt;==&gt; AzureClassUser.UserClassCode</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [InverseProperty(nameof(AzureClassUser.UserClass))]
        public virtual ICollection<AzureClassUser> UserClassAzureClassUsers { get; set; } = new HashSet<AzureClassUser>();


        /// <summary>
        /// Represents foreign key 1:M relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.Id &lt;==&gt; ConfigNode.ParentId</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [InverseProperty(nameof(ConfigNode.Parent))]
        public virtual ICollection<ConfigNode> Children { get; set; } = new HashSet<ConfigNode>();


        /// <summary>
        /// Represents foreign key 1:M relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.ParentCode &lt;==&gt; ConfigNode.ValueTypeKey</item>
        /// <item>ConfigNode.Code &lt;==&gt; ConfigNode.ValueTypeCode</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [InverseProperty(nameof(ConfigNode.ValueType))]
        public virtual ICollection<ConfigNode> ValueTypeConfigNodeValues { get; set; } = new HashSet<ConfigNode>();


        /// <summary>
        /// Represents foreign key 1:M relationship from ConfigNode to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>ConfigNode.ParentCode &lt;==&gt; ConfigNode.CodeTypeKey</item>
        /// <item>ConfigNode.Code &lt;==&gt; ConfigNode.CodeTypeCode</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [InverseProperty(nameof(ConfigNode.CodeType))]
        public virtual ICollection<ConfigNode> CodeTypeConfigNodeValues { get; set; } = new HashSet<ConfigNode>();


    }

}
