using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class ChoiceQuestion : AbstractQuestion
   {

       private List<ChoiceQuestion> _choiceList;

       public List<ChoiceQuestion> ChoiceList
       {
           get { return _choiceList; }
           set { _choiceList = value; }
       }
   }
}
