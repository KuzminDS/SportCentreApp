//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportCentre.MVC.Models
{
    using System;
    
    public partial class GetClientsBySubscription_Result
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Nullable<int> IdGroup { get; set; }
        public int IdClient { get; set; }
        public Nullable<int> IdSubscription { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Validity { get; set; }
    }
}
