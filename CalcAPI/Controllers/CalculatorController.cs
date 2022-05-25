using DataService.Calculator;
using DataService.Calculator.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ISimpleCalculator data = new SimpleCalculator();

        #region POSTS 
        [DisableCors]
        [HttpPost]
        public async Task<ActionResult<string>> PostCalculate(CalculatorInputVM Input)
        {
            var result = "Error";


            try
            {
                switch (Input.Operator)
                {
                    case "+":
                        result = data.Add(Input.FirstNumber, Input.SecondNumber).ToString();
                    break;
                    case "-":
                        result = data.Subtract(Input.FirstNumber, Input.SecondNumber).ToString();
                    break;
                    case "X":
                        result = data.Multiply(Input.FirstNumber, Input.SecondNumber).ToString();
                    break;
                    case "/":
                       result = data.Divide(Input.FirstNumber, Input.SecondNumber).ToString();
                    break;
                    default:
                       result = "Invalid Operator";
                    break;
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            
            return result;
        }

        #endregion
    }
}
