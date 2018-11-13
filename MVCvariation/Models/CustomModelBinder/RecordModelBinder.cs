
using HomeIO.Models.Entities;
using System;
using System.Web;
using System.Web.Mvc;

namespace HomeIO.Models.CustomModelBinder
{
    public class RecordModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Record))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                int recordId = Convert.ToInt32(request.Form.Get("StudentId").ToString());
                string recordType = request.Form.Get("Address");

                string frmCountry = request.Form.Get("Country");
                int frmMarks = Convert.ToInt32(request.Form.Get("Marks").ToString());

                return new Record
                {
                    Id = "",
                    Type = new RType {
                        recordType
                    },
                    CurrentValue = "",
                    Date = ""
                };


            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}