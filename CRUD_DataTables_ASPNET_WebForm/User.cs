using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DataTables_ASPNET_WebForm
{
    public class User
    {
        public long RowID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime JoinedDate  { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}