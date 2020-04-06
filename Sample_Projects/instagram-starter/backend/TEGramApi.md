# TEGram REST API
The following methods will be available in the TEGram REST API.  


| | Verb | API | Description | Request Body | Response Body |
| - | ------ | ------------ | --- | --- | --- |
| **Posts** | GET | api/posts | Get all posts with comments | None | Array of posts |
| | GET | api/posts/{post-id} | Get post by Id with comments | None | Post item |
| | POST | api/posts | Create new post | Post item | Post item |
| **Comments** | POST | api/posts/{post-id}/comments | Create comment for post | Comment item | Comment item |
| | DELETE | api/comments/{comment-id} | Delete comment from post | None | None |
| **Likes** | GET | api/posts/{post-id}/likes | Get all likes for post | None | Array of Users who like post |
| | POST | api/posts/{post-id}/likes | Like a post (for the current user) | Like item | The number of likes there are now on this post |
| | DELETE | api/posts/{post-id}/likes | Un-like a post (for the current user) | None | The number of likes there are now on this post |
| **Favorites** | GET | api/favorites | Get favorite posts for the current user | None | Array of posts |
| | POST | api/posts/{post-id}/favorites | Add post as favorite | Favorite item | None |
| | DELETE | api/posts/{post-id}/favorites | Dis-favor a post | None | None |


Here is the structure for a post

```
{
    "id": 332,
    "userId": 91,
    "userName": "James",
    "userImage": "https://ui-avatars.com/api/?name=Rick+Astley&length=2&size=128&rounded=true&color=FFD700&background=8B4513&uppercase=false&bold=true",
    "image": "https://inhabitat.com/files/2010/03/Jan-Vormann-Lego-Brick.jpg",
    "caption": "Inspired....😍",
    "dateTimeStamp": "2019-03-29T12:44:34.907",
    "numberOfLikes": 3,
    "isLiked": true,
    "isFavored": false,
    "comments": [
        {
            "id": 189,
            "postId": 332,
            "userId": 92,
            "userName": "Joe",
            "userImage": "https://ui-avatars.com/api/?name=Rick+Astley&length=2&size=128&rounded=true&color=FFD700&background=8B4513&uppercase=false&bold=true",            
            "message": "this reminds me of a scene from my favorite lego movie",
            "dateTimeStamp": "2019-03-29T12:44:34.907"
        },
        {
            "id": 429,
            "postId": 332,
            "userId": 317,
            "userName": "Johanna",
            "userImage": "https://ui-avatars.com/api/?name=Rick+Astley&length=2&size=128&rounded=true&color=FFD700&background=8B4513&uppercase=false&bold=true",            
            "message": "A new and fancy comment",
            "dateTimeStamp": "2019-04-01T16:03:42.06"
        }
    ]
}
```
