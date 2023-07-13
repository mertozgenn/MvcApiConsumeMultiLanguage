using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HomeManager : IHomeService
    {
        public IDataResult<string> GetTestData()
        {
            var langCode = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName; // send to data access layer.
            return new SuccessDataResult<string>(Messages.Hi);
        }
    }
}
