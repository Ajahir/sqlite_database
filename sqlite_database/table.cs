
using SQLite;


namespace sqlite_database
{
    [Table("table")]
    class table
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]

        public int id { get; set; } // AutoIncrement and set primarykey  

        [MaxLength(25)]

        public string StudentName { get; set; }

        [MaxLength(25)]

        public string NickName { get; set; }

        [MaxLength(25)]

        public string Dept { get; set; }

        [MaxLength(25)]

        public string Place { get; set; }
    }
}