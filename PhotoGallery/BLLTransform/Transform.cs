using BLLEntities;
using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTransform
{
    public static class Transform
    {
        public static IEnumerable<AutoSuggestEntity> TagToAutoSuggestEntity(IEnumerable<Tag> tags)
        {
            List<AutoSuggestEntity> Result = new List<AutoSuggestEntity>();
            foreach (var tag in tags)
            {
                Result.Add(new AutoSuggestEntity(tag));
            }
            return Result;
        }

        public static IEnumerable<AutoSuggestEntity> CommentToAutoSuggestEntity(IEnumerable<Comment> comments)
        {
            List<AutoSuggestEntity> Result = new List<AutoSuggestEntity>();
            foreach (var comment in comments)
            {
                Result.Add(new AutoSuggestEntity(comment));
            }
            return Result;
        }

        public static IEnumerable<AutoSuggestEntity> UserToAutoSuggestEntity(IEnumerable<User> users)
        {
            List<AutoSuggestEntity> Result = new List<AutoSuggestEntity>();
            foreach (var user in users)
            {
                Result.Add(new AutoSuggestEntity(user));
            }
            return Result;
        }

        public static ICollection<Comment> CommentEntityToComment(ICollection<CommentEntity> comments)
        {
            HashSet<Comment> Comments = new HashSet<Comment>();
            foreach (var comment in comments)
            {
                Comments.Add(new Comment 
                { 
                    CommentId = comment.CommentId, 
                    CommentDate = comment.CommentDate, 
                    CommentNumber = comment.CommentNumber,
                    CommentParentNumber = comment.CommentParentNumber, 
                    CommentText = comment.CommentText, 
                    UserId = comment.UserId, 
                    ImageId = comment.UserId
                });
            }
            return Comments;
        }

        public static CommentEntity[] CommentToCommentEntity(Comment[] comments)
        {
            CommentEntity[] Comments = new CommentEntity[comments.Length];
            for (int i = 0; i < comments.Length; i++)
            {
                Comments[i] = new CommentEntity(comments[i]);
            }
            return Comments;
        }

        public static ICollection<Image> ImageEntityToImage(ICollection<ImageEntity> images)
        {
            HashSet<Image> Images = new HashSet<Image>();
            foreach (var image in images)
            {
                Images.Add(new Image { ImageId = image.ImageId, ImagePicture = image.ImagePicture, UserId = image.UserId, Comment = CommentEntityToComment(image.Comment), Tag = TagEntityToTag(image.Tag) });
            }
            return Images;
        }

        public static ImageEntity[] ImageToImageEntity(Image[] images)
        {
            ImageEntity[] Images = new ImageEntity[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                Images[i] = new ImageEntity(images[i]);
            }
            return Images;
        }

        public static ICollection<Role> RoleEntityToRole(ICollection<RoleEntity> roles)
        {
            HashSet<Role> Roles = new HashSet<Role>();
            foreach (var role in roles)
            {
                Roles.Add(new Role { RoleId = role.RoleId, RoleName = role.RoleName });
            }
            return Roles;
        }

        public static RoleEntity[] RoleToRoleEntity(Role[] roles)
        {
            RoleEntity[] Roles = new RoleEntity[roles.Length];
            for (int i = 0; i < roles.Length; i++)
            {
                Roles[i] = new RoleEntity(roles[i]);
            }
            return Roles;
        }

        public static ICollection<Tag> TagEntityToTag(ICollection<TagEntity> tags)
        {
            HashSet<Tag> Tags = new HashSet<Tag>();
            foreach (var tag in tags)
            {
                Tags.Add(new Tag { TagId = tag.TagId, TagName = tag.TagName, Image = ImageEntityToImage(tag.Image) });
            }
            return Tags;
        }

        public static TagEntity[] TagToTagEntity(Tag[] tags)
        {
            TagEntity[] Tags = new TagEntity[tags.Length];
            for (int i = 0; i < tags.Length; i++)
            {
                Tags[i] = new TagEntity(tags[i]);
            }
            return Tags;
        }        

        public static UserEntity[] UserToUserEntity(User[] users)
        {
            UserEntity[] Users = new UserEntity[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                Users[i] = new UserEntity(users[i]);
            }
            return Users;
        }
    }
}
