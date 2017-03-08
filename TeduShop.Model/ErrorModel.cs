using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Model
{
    public class ErrorModel
    {
        [Key]
        public int ID { set; get; }

        public string Message { set; get; }

        public string StackTrace { set; get; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}