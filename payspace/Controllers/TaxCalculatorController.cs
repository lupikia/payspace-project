using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using payspace.features;
using payspace.Model;

namespace payspace.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {

        private Validations validation = new Validations();
        private DataFormat clean_format = new DataFormat();


        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] TaxCalculatorModel data)
        {
            try
            {
                //-->validate the passed data
                clean_format.Format(data);

                validation.Validate_form(clean_format.form);
                TaxCalculatorModel cleaned_data = clean_format.Get_Format_anything<TaxCalculatorModel>();
                

                    return StatusCode(200,"Project is incomplete");

                throw new Exception_handler(2, new { error = "Database connection failed" });
             }
            catch (Exception_handler error)
            {
                if (!error.response_with_data)
                {
                    return StatusCode(500, error.Message);
                }
                else
                {
                     return StatusCode(500,error.Exception_handler_full_error());
                }
            }
            catch (Exception es)
            {
                return StatusCode( 500, es.Message);

            }
        }


    }
}
