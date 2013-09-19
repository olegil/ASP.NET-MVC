using DALEntities;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALDatabase
{
    public class ImageDAL : ImageIRepository
    {
        public int SaveImage(Image image)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Image.Add(image);
                DB.SaveChanges();
                return DB.Image.ToArray()[DB.Image.ToArray().Length - 1].ImageId;
            }
        }

        public Image GetImage(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Image.First(image => image.ImageId == ImageId);
            }
        }

        public IEnumerable<string> GetImageTagNames(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Image.First(image => image.ImageId == ImageId).Tag.Select(tag => tag.TagName).ToArray();
            }
        }

        public Image GetImageByCommentId(int CommentId)
        {
            using (var DB = new DatabaseEntities())
            {
                var Comment = DB.Comment.First(comment => comment.CommentId == CommentId);
                return DB.Image.First(image => image.ImageId == Comment.ImageId);
            }
        }

        public Image[] GetAllImages()
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Image.ToArray();
            }
        }

        public int GetAllImagesCount()
        {
            using (var DB = new DatabaseEntities())
            {
                return DB.Image.Count();
            }
        }

        public IEnumerable<Image> GetImages(int StartIndex, int Count)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Result = new List<Image>();
                for (int i = StartIndex; i < DB.Image.Count() && Result.Count != Count; i++)
                {
                    Result.Add(DB.Image.ToArray()[i]);
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesByCommentId(int CommentId)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Result = new List<Image>();
                var Comment = DB.Comment.First(comment => comment.CommentId == CommentId);
                List<Comment> Comments = new List<Comment>();
                foreach (var comment in DB.Comment)
                {
                    if (comment.CommentText == Comment.CommentText)
                    {
                        Comments.Add(comment);
                    }
                }
                foreach (var image in DB.Image)
                {
                    foreach (var comment in Comments)
                    {
                        if (image.Comment.Contains(comment))
                        {
                            Result.Add(image);
                            break;
                        }
                    }
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesByCommentId(int CommentId, int StartIndex, int Count)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Temp = new List<Image>();
                List<Image> Result = new List<Image>();
                var Comment = DB.Comment.First(comment => comment.CommentId == CommentId);
                List<Comment> Comments = new List<Comment>();
                foreach (var comment in DB.Comment)
                {
                    if (comment.CommentText == Comment.CommentText)
                    {
                        Comments.Add(comment);
                    }
                }
                foreach (var image in DB.Image)
                {
                    foreach (var comment in Comments)
                    {
                        if (image.Comment.Contains(comment))
                        {
                            Temp.Add(image);
                            break;
                        }
                    }
                }
                for (int i = StartIndex; i < Temp.Count && Result.Count != Count; i++)
                {
                    Result.Add(Temp[i]);
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesByTagId(int TagId)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Result = new List<Image>();
                var Tag = DB.Tag.First(tag => tag.TagId == TagId);
                foreach (var image in DB.Image)
                {
                    if (image.Tag.Contains(Tag))
                    {
                        Result.Add(image);
                    }
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesByTagId(int TagId, int StartIndex, int Count)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Temp = new List<Image>();
                List<Image> Result = new List<Image>();
                var Tag = DB.Tag.First(tag => tag.TagId == TagId);
                foreach (var image in DB.Image)
                {
                    if (image.Tag.Contains(Tag))
                    {
                        Temp.Add(image);
                    }
                }
                for (int i = StartIndex; i < Temp.Count && Result.Count != Count; i++)
                {
                    Result.Add(Temp[i]);
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesBySearchName(string Name)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Result = new List<Image>();
                bool Flag = false;
                foreach (var image in DB.Image)
                {
                    Flag = false;
                    foreach (var tag in image.Tag)
                    {
                        if (tag.TagName.ToLower().Contains(Name.ToLower()))
                        {
                            Result.Add(image);
                            Flag = true;
                            break;
                        }
                    }
                    if (Flag)
                    {
                        foreach (var comment in image.Comment)
                        {
                            if (comment.CommentText.ToLower().Contains(Name.ToLower()))
                            {
                                Result.Add(image);
                                break;
                            }
                        }
                    }
                }
                return Result;
            }
        }

        public IEnumerable<Image> GetImagesBySearchName(string Name, int StartIndex, int Count)
        {
            using (var DB = new DatabaseEntities())
            {
                List<Image> Temp = new List<Image>();
                for (int i = StartIndex; i < DB.Image.Count() && Temp.Count != Count; i++)
                {
                    Temp.Add(DB.Image.ToArray()[i]);
                }
                List<Image> Result = new List<Image>();
                bool Flag = false;
                foreach (var image in Temp)
                {
                    Flag = false;
                    foreach (var tag in image.Tag)
                    {
                        if (tag.TagName.ToLower().Contains(Name.ToLower()))
                        {
                            Result.Add(image);
                            Flag = true;
                            break;
                        }
                    }
                    if (Flag)
                    {
                        foreach (var comment in image.Comment)
                        {
                            if (comment.CommentText.ToLower().Contains(Name.ToLower()))
                            {
                                Result.Add(image);
                                break;
                            }
                        }
                    }
                }
                return Result;
            }
        }

        public IEnumerable<int> GetImageIds(int StartIndex, int Count)
        {
            using (var DB = new DatabaseEntities())
            {
                List<int> Result = new List<int>();
                for (int i = StartIndex; i < DB.Image.Count() && Result.Count != Count; i++)
                {
                    Result.Add(DB.Image.ToArray()[i].ImageId);
                }
                return Result;
            }
        }

        public int GetImageIndexByImageId(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                var Images = DB.Image.ToArray();
                for (int i = 0; i < Images.Length; i++)
                {
                    if (Images[i].ImageId == ImageId)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        public void RemoveImage(int ImageId)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Image.First(image => image.ImageId == ImageId).Tag.Clear();
                DB.Image.Remove(DB.Image.First(image => image.ImageId == ImageId));
                DB.SaveChanges();
            }
        }

        public void AddImageTag(int ImageId, int TagId)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Image.First(image => image.ImageId == ImageId).Tag.Add(DB.Tag.First(tag => tag.TagId == TagId));
                DB.SaveChanges();
            }
        }

        public void RemoveImageTag(int ImageId, int TagId)
        {
            using (var DB = new DatabaseEntities())
            {
                DB.Image.First(image => image.ImageId == ImageId).Tag.Remove(DB.Tag.First(tag => tag.TagId == TagId));
                DB.SaveChanges();
            }
        }

        public bool ContainsImageTag(int ImageId, string TagName)
        {
            using (var DB = new DatabaseEntities())
            {
                foreach (var tag in DB.Image.First(image => image.ImageId == ImageId).Tag)
                {
                    if (tag.TagName == TagName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
