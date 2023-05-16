using System;

namespace SocialNetwork.API.Searches
{
    //{
    //    "dateFrom": "2022-01-01",
    //    "dateTo": "2023-01-01",
    //    "hashTag": "t1",
    //    "user": "pera",
    //    "hasComments": null
    //}
    public class PostSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Username { get; set; }
        public string HashTag { get; set; }
        public bool? HasComments { get; set; }
    }
}
