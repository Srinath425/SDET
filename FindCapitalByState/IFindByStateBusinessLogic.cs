using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCapitalByState
{
    public interface IFindByStateBusinessLogic
    {
        /// <summary>
        /// The Find City By State
        /// </summary>
        /// <param name="stateName">The stateName</param>
        /// <returns>returns state model as result</returns>
        StateModel FindCityByState(string stateName);

        /// <summary>
        /// The HttpGetResponse
        /// </summary>
        /// <returns>returns http response string</returns>
        string HttpGetResponse();
    }
}
