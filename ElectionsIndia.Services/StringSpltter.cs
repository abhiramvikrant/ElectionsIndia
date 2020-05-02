using System;
using System.Collections.Generic;
using System.Text;
using ElectionsIndia.Models.ViewModels;
using ElectionsIndia.Services.Interfaces;

namespace ElectionsIndia.Services
{
   public  class StringSpltter : IStringSplitter {
        public List<SplitterReturnViewModel> SendTArray(string message)
        {
            var stringarray = message.Split(Environment.NewLine);
            List<string> myobject = new List<string>();
            foreach (var item in stringarray)
            {

                myobject.Add(item);
            }
            List<SplitterReturnViewModel> objModel =  ParseList(myobject);
            return objModel;
        }

        private List<SplitterReturnViewModel> ParseList(List<string> model)
        {
            List<SplitterReturnViewModel> returnModel = new List<SplitterReturnViewModel>();
            for (int i = 0; i < model.Count; i++)
            { var obj = model[i].Split(',');
                if (obj.Length == 2)
                {
                    returnModel.Add(new SplitterReturnViewModel { Name = obj[0], IsActive = Convert.ToBoolean(obj[1]) });
                }
                else if (obj.Length == 3)
                {
                    var newModel = new SplitterReturnViewModel();
                    newModel.Name = obj[0];
                    
                    returnModel.Add(new SplitterReturnViewModel { Name = obj[0], IsActive = Convert.ToBoolean(obj[1]) ,
                    IsUT = Convert.ToBoolean(obj[2])});
                }

            }

            return returnModel;

            
        }
       
    }
}
