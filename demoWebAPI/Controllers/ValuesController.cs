using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace demoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DateTime localDate = DateTime.Now;

            var dateCondition = CalcularPrimerPagoSimulador(localDate, 10, 0);

            var resIni = DateFormatSimulador(dateCondition, default);
            var resFin = DateFormatSimulador(dateCondition, 24);

            var input = "";

            return new string[] { resIni, resFin };
        }

        public static string DateFormatSimulador(DateTime input, int plazo) => plazo == default(int) ? input.ToString("yyyyMMdd") : input.AddMonths(plazo).ToString("yyyyMMdd");

        public static DateTime CalcularPrimerPagoSimulador(DateTime date, int diapago, int periodogracia)
        {
            var Fpago = diapago == default(int) ? date.Day : diapago;
            var months = Fpago - date.Day < 30 ? 1 : default(int);
            var fecha = new DateTime(date.Year, date.Month, Fpago);
            if (Fpago < date.Day)
                fecha = fecha.AddMonths(1);
            var dateLogica = fecha.AddDays(periodogracia);
                dateLogica = dateLogica.AddMonths(months);
            return dateLogica;
        }

        // GET api/values/5
        [HttpGet("{daypayment}/{gracePeriod}/{plazo}")]
        public ActionResult<IEnumerable<string>> Get(int daypayment, int gracePeriod, int plazo)
        {
            DateTime localDate = DateTime.Now;

            var dateCondition = CalcularPrimerPagoSimulador(localDate, daypayment, gracePeriod);

            var resIni = DateFormatSimulador(dateCondition, default);
            var resFin = DateFormatSimulador(dateCondition, plazo);

            return new string[] { resIni, resFin };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public static int parseInt(string value)
        {
            int resul;
            try
            {
                resul = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return -1;
            }
            return resul;
        }

        public static List<string> validateChannelNumber (string input, string separador){
            var inputs = input.Split(separador);

            var channerror = new List<string>();
            inputs.ToList().ForEach(f => {
                if (parseInt(f) == -1)
                    channerror.Add(f);
            });
            return channerror;
        }

        public static List<string> validateExistChannel (string input, string separador, string[] channels)
        {
            var result = new List<string>();
            var stringchannels = input.Split(separador);
            var listChannels = channels.ToList();

            if (input.Length > 0)
            {
                var listInput = stringchannels.Select(s => Convert.ToInt32(s).ToString("D2").ToString()).ToList();
                    listInput.RemoveAll(x => listChannels.Any(s => x == s));
                result = listInput;
            }

            return result;
        }
    }
}
