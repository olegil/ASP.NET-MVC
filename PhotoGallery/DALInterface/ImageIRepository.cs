using DALEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface
{
    public interface ImageIRepository
    {
        Image GetImage(int ImageId);
        Image GetImageByCommentId(int CommentId);
        Image[] GetAllImages();
        int SaveImage(Image image);
        IEnumerable<string> GetImageTagNames(int ImageId);
        int GetAllImagesCount();
        IEnumerable<Image> GetImages(int StartIndex, int Count);
        IEnumerable<Image> GetImagesByCommentId(int CommentId);
        IEnumerable<Image> GetImagesByCommentId(int CommentId, int StartIndex, int Count);
        IEnumerable<Image> GetImagesByTagId(int TagId);
        IEnumerable<Image> GetImagesByTagId(int TagId, int StartIndex, int Count);
        IEnumerable<Image> GetImagesBySearchName(string Name);
        IEnumerable<Image> GetImagesBySearchName(string Name, int StartIndex, int Count);
        IEnumerable<int> GetImageIds(int StartIndex, int Count);
        int GetImageIndexByImageId(int ImageId);
        void RemoveImage(int ImageId);
        void AddImageTag(int ImageId, int TagId);
        void RemoveImageTag(int ImageId, int TagId);
        bool ContainsImageTag(int ImageId, string TagName);
    }
}
