using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace ConvertTxtDictionaryToDB.SQLite
{
    [Table(Name = "Words")]
    public class Words
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "Word", DbType = "TEXT")]
        public string Word { get; set; }

        [Column(Name = "MetaData", DbType = "TEXT")]
        public string MetaData { get; set; }

        [Column(Name = "Definition", DbType = "TEXT")]
        public string Definition { get; set; }

        [Column(Name = "SyllableCount", DbType = "INTEGER")]
        public int? SyllableCount { get; set; }

        [Column(Name = "IsNoun", DbType = "INTEGER")]
        public int? IsNoun { get; set; }

        [Column(Name = "IsPronoun", DbType = "INTEGER")]
        public int? IsPronoun { get; set; }

        [Column(Name = "IsVerb", DbType = "INTEGER")]
        public int? IsVerb { get; set; }

        [Column(Name = "IsAdjective", DbType = "INTEGER")]
        public int? IsAdjective { get; set; }

        [Column(Name = "IsAdverb", DbType = "INTEGER")]
        public int? IsAdverb { get; set; }

        [Column(Name = "IsTransitiveVerb", DbType = "INTEGER")]
        public int? IsTransitiveVerb { get; set; }

        [Column(Name = "IsIntransitiveVerb", DbType = "INTEGER")]
        public int? IsIntransitiveVerb { get; set; }

        [Column(Name = "IsPreposition", DbType = "INTEGER")]
        public int? IsPreposition { get; set; }

        [Column(Name = "IsConjunction", DbType = "INTEGER")]
        public int? IsConjunction { get; set; }

        [Column(Name = "IsInterjection", DbType = "INTEGER")]
        public int? IsInterjection { get; set; }

        [Column(Name = "IsPlural", DbType = "INTEGER")]
        public int? IsPlural { get; set; }

        [Column(Name = "IsSingular", DbType = "INTEGER")]
        public int? IsSingular { get; set; }
    }
}
