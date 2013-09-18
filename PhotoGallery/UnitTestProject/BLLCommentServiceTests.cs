using BLLEntities;
using BLLCommentService;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class BLLCommentServiceTests
    {
        [TestMethod]
        public void CommentParserTextMessageWithoutParentId()
        {
            CommentEntity[] Comments = new CommentEntity[1] {
                new CommentEntity { CommentDate = new DateTime(2000, 1, 1), CommentText = "abcd", CommentParentNumber = 0, ImageId = 1, UserId = 1 }
            };
            Assert.AreEqual(Comments[0], BLLCommentService.CommentParser.BuildComments(new DateTime(2000, 1, 1), "abcd", 1, 1)[0]);
        }

        [TestMethod]
        public void CommentParserTextMessageWithOneParentId()
        {
            CommentEntity[] Comments = new CommentEntity[1] {
                new CommentEntity { CommentDate = new DateTime(2000, 1, 1), CommentText = "abcd", CommentParentNumber = 1, ImageId = 1, UserId = 1 }
            };
            Assert.AreEqual(Comments[0], BLLCommentService.CommentParser.BuildComments(new DateTime(2000, 1, 1), ">>1\nabcd", 1, 1)[0]);
        }

        [TestMethod]
        public void CommentParserTextMessageWithTwoParentId()
        {
            CommentEntity[] Comments = new CommentEntity[2] {
                new CommentEntity { CommentDate = new DateTime(2000, 1, 1), CommentText = "abcd", CommentParentNumber = 1, ImageId = 1, UserId = 1 },
                new CommentEntity { CommentDate = new DateTime(2000, 1, 1), CommentText = "abcd", CommentParentNumber = 2, ImageId = 1, UserId = 1 }
            };
            Assert.AreEqual(Comments, BLLCommentService.CommentParser.BuildComments(new DateTime(2000, 1, 1), ">>1\n>>2\nabcd", 1, 1));
        }
    }
}
