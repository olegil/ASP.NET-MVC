using BLLEntities;
using BLLTransform;
using DALEntities;
using DALFactory;
using DALInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServices
{
    public static class ImageBLLService
    {
        public static bool ContainsImageTag(int ImageId, string TagName)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return ImageRepository.ContainsImageTag(ImageId, TagName);
        }

        public static void AddImageTag(int ImageId, int TagId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            ImageRepository.AddImageTag(ImageId, TagId);
        }

        public static void RemoveImageTag(int ImageId, int TagId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            ImageRepository.RemoveImageTag(ImageId, TagId);
        }

        public static void SaveImage(ImageEntity image)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            int ImageId = ImageRepository.SaveImage(new Image {
                ImagePicture = image.ImagePicture,
                UserId = image.UserId,
                Comment = Transform.CommentEntityToComment(image.Comment),
                Tag = new HashSet<Tag>()
            });
            foreach (var tag in image.Tag)
            {
                ImageRepository.AddImageTag(ImageId, tag.TagId);
            }
        }

        public static IEnumerable<string> GetImageTagNames(int ImageId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return ImageRepository.GetImageTagNames(ImageId);
        }

        public static ImageEntity GetImage(int ImageId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return new ImageEntity(ImageRepository.GetImage(ImageId));
        }

        public static ImageEntity GetImageByCommentId(int CommentId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return new ImageEntity(ImageRepository.GetImageByCommentId(CommentId));
        }

        public static ImageEntity[] GetAllImages()
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetAllImages());
        }

        public static int GetAllImagesCount()
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return ImageRepository.GetAllImagesCount();
        }

        public static IEnumerable<ImageEntity> GetImages(int StartIndex, int Count)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImages(StartIndex, Count).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesByCommentId(int CommentId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesByCommentId(CommentId).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesByCommentId(int CommentId, int StartIndex, int Count)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesByCommentId(CommentId, StartIndex, Count).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesByTagId(int TagId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesByTagId(TagId).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesByTagId(int TagId, int StartIndex, int Count)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesByTagId(TagId, StartIndex, Count).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesBySearchName(string Name)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesBySearchName(Name).ToArray());
        }

        public static IEnumerable<ImageEntity> GetImagesBySearchName(string Name, int StartIndex, int Count)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return Transform.ImageToImageEntity(ImageRepository.GetImagesBySearchName(Name, StartIndex, Count).ToArray());
        }        

        public static IEnumerable<int> GetImageIds(int StartIndex, int Count)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return ImageRepository.GetImageIds(StartIndex, Count);
        }

        public static int GetImageIndexByImageId(int ImageId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            return ImageRepository.GetImageIndexByImageId(ImageId);
        }

        public static void RemoveImage(int ImageId)
        {
            ImageIRepository ImageRepository = RepositoryFactory.GetImageRepository();
            ImageEntity Image = new ImageEntity(ImageRepository.GetImage(ImageId));
            if (Image.Comment.Count != 0)
            {
                CommentBLLService.RemoveCommentsByImageId(ImageId);
            }
            ImageRepository.RemoveImage(ImageId);
        }
    }
}
