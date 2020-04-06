DELETE FROM favorites;
DELETE FROM likes;
DELETE FROM comments;
DELETE FROM posts;
DELETE FROM users;

-- Insert a test user
DECLARE @newUserOneName varchar(30) = 'legoman';
INSERT INTO users(username, password, salt, image) VALUES(@newUserOneName, '', '', 'https://randomuser.me/api/portraits/lego/2.jpg');
DECLARE @newUserOneId int = (SELECT @@IDENTITY)

DECLARE @newUserTwoName varchar(30) = 'bottletopguy';
INSERT INTO users(username, password, salt, image) VALUES(@newUserTwoName, '', '', 'https://randomuser.me/api/portraits/lego/4.jpg');
DECLARE @newUserTwoId int = (SELECT @@IDENTITY)

-- Insert a test post
INSERT INTO posts(user_id, image, caption) VALUES(@newUserOneId, 'https://inhabitat.com/files/2010/03/Jan-Vormann-Lego-Brick.jpg',N'Inspired....😍');
DECLARE @newPostId int = (SELECT @@IDENTITY)
INSERT INTO posts(user_id, image, caption) VALUES(@newUserTwoId, 'https://inhabitat.com/files/2010/03/Jan-Vormann-Lego-Brick.jpg',N'Whatever');
DECLARE @newPostTwoId int = (SELECT @@IDENTITY)
INSERT INTO posts(user_id, image, caption) VALUES(@newUserOneId, 'https://www.k9ofmine.com/wp-content/uploads/2017/06/best-dog-booties-800x534.jpg',N'Staying DRY');

-- Insert a test comment
INSERT INTO comments(post_id, user_id, message) VALUES(@newPostId, @newUserTwoId, N'this reminds me of a scene from my favorite lego movie');
DECLARE @commentId int = (SELECT @@IDENTITY)
INSERT INTO comments(post_id, user_id, message) VALUES(@newPostTwoId, @newUserOneId, N'Some other text');

-- Insert a test like
INSERT INTO likes(post_id, user_id) VALUES(@newPostId, @newUserTwoId);
INSERT INTO likes(post_id, user_id) VALUES(@newPostTwoId, @newUserOneId);

-- Insert a test favorite
INSERT INTO favorites(post_id, user_id) VALUES(@newPostId, @newUserTwoId);
INSERT INTO favorites(post_id, user_id) VALUES(@newPostId, @newUserOneId);

-- Return the id of the new test users and post
SELECT @newUserOneId as newUserOneId, @newUserOneName as newUserOneName,
	@newUserTwoId as newUserTwoId, @newUserTwoName as newUserTwoName, 
	@newPostId as newPostId, @commentId as newCommentId; 
