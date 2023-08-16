using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace odata_error.Models
{

    /// <summary>
    /// Represents the store table ODataTest.AzureClassUser, the entity set name is AzureClassUsers
    /// </summary>
    [Table("AzureClassUser")]
    public partial class AzureClassUser
    {

        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.Id
        /// </summary>
        [Key]
        [Column("Id")]
        [Required]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.FirstName
        /// </summary>
        [Column("FirstName", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Required]
        [DataMember]
        public virtual string? FirstName { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.LastName
        /// </summary>
        [Column("LastName", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Required]
        [DataMember]
        public virtual string? LastName { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.Age
        /// </summary>
        [Column("Age")]
        [DataMember]
        public virtual int? Age { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.Rating
        /// </summary>
        [Column("Rating", TypeName = "decimal(8,2)")]
        [DataMember]
        public virtual decimal? Rating { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.UserClassKey
        /// </summary>
        [Column("UserClassKey", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        [DefaultValue("USER_CLASS_TYPE")]
        public virtual string? UserClassKey { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.UserClassCode
        /// </summary>
        [Column("UserClassCode", TypeName = "varchar(100)")]
        [MaxLength(100)]
        [DataMember]
        public virtual string? UserClassCode { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.IsDeleted
        /// </summary>
        [Column("IsDeleted")]
        [DataMember]
        public virtual bool? IsDeleted { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.LastReviewedDate
        /// </summary>
        [Column("LastReviewedDate")]
        [DataMember]
        public virtual DateTime? LastReviewedDate { get; set; }


        /// <summary>
        /// Represents the store column ODataTest.AzureClassUser.TestEvent
        /// </summary>
        [Column("TestEvent", TypeName = "datetime")]
        [DataMember]
        public virtual DateTime? TestEvent { get; set; }


        /// <summary>
        /// Represents foreign key 1:1 relationship from AzureClassUser to ConfigNode
        /// </summary>
        /// <remarks>
        /// Foreign Keys:
        /// <list type="bullet">
        /// <item>AzureClassUser.UserClassKey &lt;==&gt; ConfigNode.ParentCode</item>
        /// <item>AzureClassUser.UserClassCode &lt;==&gt; ConfigNode.Code</item>
        /// </list>
        /// </remarks>
        [DataMember]
        [ForeignKey(nameof(AzureClassUser.UserClassKey) + "," + nameof(AzureClassUser.UserClassCode))]
        public virtual ConfigNode? UserClass { get; set; }


    }

}
