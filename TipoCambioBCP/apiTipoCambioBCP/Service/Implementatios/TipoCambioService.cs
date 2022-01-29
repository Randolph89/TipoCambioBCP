using apiTipoCambioBCP.CrossCutting.Dto;
using apiTipoCambioBCP.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambioBCP.Service.Implementatios
{
    public class TipoCambioService : ITipoCambioService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TipoCambioService(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this._configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<List<TipoCambioDto>> GetTipoCambio(int codMoneda)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var vListDataTipoCambio = new List<TipoCambioDto>();
            using (var reader = new StreamReader(contentRootPath + @"\Data\agencias.json"))
            {
                var json = reader.ReadToEnd();
                vListDataTipoCambio = JsonConvert.DeserializeObject<List<TipoCambioDto>>(json);
            }

            return vListDataTipoCambio.FindAll(x => x.codMoneda == codMoneda);
        }

        public async Task<List<TipoCambioDto>> GetMonedas()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var vListDataMonedas = new List<TipoCambioDto>();
            using (var reader = new StreamReader(contentRootPath + @"\Data\agencias.json"))
            {
                var json = reader.ReadToEnd();
                vListDataMonedas = JsonConvert.DeserializeObject<List<TipoCambioDto>>(json);
            }

            return vListDataMonedas;
        }
    }
}
