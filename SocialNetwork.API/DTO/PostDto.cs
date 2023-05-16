using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.API.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Modified { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> HashTags { get; set; }
        public IEnumerable<PostFileDto> Files { get; set; }
        public IEnumerable<PostReactionDto> Reactions { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }

    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentedAt { get; set; }
        public string Username { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<PostReactionDto> Reactions { get; set; }
        public IEnumerable<CommentDto> ChildComments { get; set; }
    }

    public class PostFileDto
    {
        public string Path { get; set; }
        public int Id { get; set; }
        public string Type
        {
            get
            {
                if(string.IsNullOrEmpty(Path))
                {
                    return "Unknown";
                }
                
                if(!Path.Contains("."))
                {
                    return "Unknown";
                }

                var extension = Path.Split(".")[1];

                if(ImageTypes.Contains(extension))
                {
                    return "image";
                }

                if(VideoTypes.Contains(extension))
                {
                    return "video";
                }

                return "Unknown";
            }
        }

        private IEnumerable<string> ImageTypes = new List<string>
        {
            "png", "jpg", "jpeg", "gif", "tiff"
        };

        private IEnumerable<string> VideoTypes = new List<string>
        {
            "mp4", "mov", "avi"
        };
    }

    public class PostReactionDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime ReactedAt { get; set; }
        public string Icon { get; set; }
    }

//    [
//    {
//        "id": 1,
//        "text": "Opis objave",
//        "createdAt": "2022-11-23 11:48",
//        "modifiedAt": null,
//        "reactions": [
//            { 
//               "id": 5,
//               "username": "pera",
//               "reactedAt" : "2022-11-23 12:01",
//               "icon": "like.png"  
//            },
//            {
//    "id": 5, 
//               "username": "mika", 
//               "reactedAt" : "2022-11-23 12:05", 
//               "icon": "like.png"
//            },
//            {
//    "id": 6, 
//               "username": "joca", 
//               "reactedAt" : "2022-11-23 12:012", 
//               "icon": "thumbs-down.png"
//            }
//         ],
//         "comments": [
//            {
//                "id": 1,
//                "username": "pera",
//                "text": "Super!",
//                "createdAt": "2022-11-23 12:15",
//                "childComments": [
//                    {
//                        "id": 1,
//                        "createdAt": "2022-11-23 12:18",
//                        "username": "mika",
//                        "text": "Extra!",
//                        "childComments": [],
//                        "reactions": []
//                    }
//                ],
//                "reactions": [
//                    { 
//                        "id": 5,
//                        "username": "laza",
//                        "reactedAt" : "2022-11-23 12:12",
//                        "icon": "like.png"  
//                     }
//                ]
//            }
//         ],
//         "username": "laza",
//         "files": [
//            {
//                "id": 1,
//                "path": "slika1.png",
//                "type": "image"
//            },
//            {
//    "id": 2,
//                "path": "video1.mp4",
//                "type": "video"
//            }
         
//        ],
//        "hashTags": [ "t1", "t2", "t3" ] 
//    }
//]
}
