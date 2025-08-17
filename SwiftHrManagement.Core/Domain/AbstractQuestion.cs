using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public abstract class AbstractQuestion
   {
       private long _id;

       protected long Id
       {
           get { return _id; }
           set { _id = value; }
       }

       private long _categoryId;

       protected long CategoryId
       {
           get { return _categoryId; }
           set { _categoryId = value; }
       }

       private long _subCategoryId;

       protected long SubCategoryId
       {
           get { return _subCategoryId; }
           set { _subCategoryId = value; }
       }

       private string _question;

       protected string Question
       {
           get { return _question; }
           set { _question = value; }
       }

       
   }
}
